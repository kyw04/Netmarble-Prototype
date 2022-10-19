/// ---------------------------------------------
/// Rhythm Timeline
/// Copyright (c) Dyplsoom. All Rights Reserved.
/// https://www.dypsloom.com
/// ---------------------------------------------

namespace Dypsloom.RhythmTimeline.Core.Notes
{
    using UnityEngine;
    using Dypsloom.RhythmTimeline.Core.Input;
    using Dypsloom.RhythmTimeline.Core.Playables;

    /// <summary>
    /// The Tap Note detects a single press input.
    /// </summary>
    public class DoubleTapNote : Note
    {
        private DoubleTapNote secondNote = null;
        private string secondNoteTag;
        private bool noteOn = true;
        private bool miss = false;
        private bool tapped = false;
        private float spawnTime;
        private float tapTime = 0;
        public float resetTime = 0.5f;

        /// <summary>
        /// The note is initialized when it is added to the top of a track.
        /// </summary>
        /// <param name="rhythmClipData">The rhythm clip data.</param>
        public override void Initialize(RhythmClipData rhythmClipData)
        {
            base.Initialize(rhythmClipData);
            gameObject.tag = m_RhythmClipData.ClipParameters.NoteTag.ToString();
            secondNoteTag = m_RhythmClipData.ClipParameters.SecondNoteTag.ToString();
            spawnTime = Time.time;
        }

        protected override void Update()
        {
            if (secondNote == null)
            {
                Debug.Log("Search");
                GameObject[] temp = GameObject.FindGameObjectsWithTag(secondNoteTag);
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i].GetComponent<DoubleTapNote>())
                    {
                        DoubleTapNote doubleTapNote = temp[i].GetComponent<DoubleTapNote>();
                        if (doubleTapNote && doubleTapNote.spawnTime + 0.5f >= Time.time)
                        {
                            Debug.Log("Found Note");
                            secondNote = temp[i].GetComponent<DoubleTapNote>();
                        }
                    }
                }
            }

            if (tapTime + resetTime < Time.time)
                tapped = false;

            if (m_UpdateWithTimeline) { return; }

            //Debug.Log("time line update dsp"+m_DspGlobalStartTime +" end "+m_DspGlobalEndTime);
            if (m_ActivateWithClip == false)
            {
                if (m_ActiveState == ActiveState.Active && TimeFromDeactivate >= 0)
                {
                    DeactivateNote();
                }
                else if (m_ActiveState == ActiveState.PreActive && TimeFromActivate >= 0)
                {
                    ActivateNote();
                }
            }

            HybridUpdate(TimeFromActivate, TimeFromDeactivate);
        }

        public override void Reset()
        {
            secondNote = null;
            noteOn = true;
            tapped = false;
            tapTime = 0;
            miss = false;
          
            base.Reset();
        }

        protected override void ActivateNote()
        {
            base.ActivateNote();
        }

        protected override void DeactivateNote()
        {
            base.DeactivateNote();

            if (Application.isPlaying == false) { return; }

            if (m_IsTriggered == false)
            {
                InvokeNoteTriggerEventMiss();
            }

            secondNote = null;
            noteOn = true;
            tapped = false;
            tapTime = 0;
            miss = false;
        }

        /// <summary>
        /// An input was triggered on this note.
        /// The input event data has the information about what type of input was triggered.
        /// </summary>
        /// <param name="inputEventData">The input event data.</param>
        public override void OnTriggerInput(InputEventData inputEventData)
        {

            //Since this is a tap note, only deal with tap inputs.
            if (!inputEventData.Tap) { return; }

            //The gameobject can be set to active false. It is returned to the pool automatically when reset.
            tapped = true;
            tapTime = Time.time;

            if (secondNote.tapped && noteOn)
            {
                Player.Instance.SetHP();

                noteOn = false;
                secondNote.noteOn = false;

                gameObject.SetActive(false);
                m_IsTriggered = true;

                secondNote.gameObject.SetActive(false);
                secondNote.m_IsTriggered = true;

                //You may compute the perfect time anyway you want.
                //In this case the perfect time is half of the clip.
                var perfectTime = m_RhythmClipData.RealDuration / 2f;
                var timeDifference = TimeFromActivate - perfectTime;
                var timeDifferencePercentage = Mathf.Abs((float)(100f * timeDifference)) / perfectTime;

                //Send a trigger event such that the score system can listen to it.
                InvokeNoteTriggerEvent(inputEventData, timeDifference, (float)timeDifferencePercentage);
                secondNote.InvokeNoteTriggerEvent(inputEventData, timeDifference, (float)timeDifferencePercentage);
                RhythmClipData.TrackObject.RemoveActiveNote(this);
                RhythmClipData.TrackObject.RemoveActiveNote(secondNote);
            }
        }

        /// <summary>
        /// Hybrid Update is updated both in play mode, by update or timeline, and edit mode by the timeline. 
        /// </summary>
        /// <param name="timeFromStart">The time from reaching the start of the clip.</param>
        /// <param name="timeFromEnd">The time from reaching the end of the clip.</param>
        protected override void HybridUpdate(double timeFromStart, double timeFromEnd)
        {
            //Compute the perfect timing.
            var perfectTime = m_RhythmClipData.RealDuration / 2f;
            var deltaT = (float)(timeFromStart - perfectTime);

            //Compute the position of the note using the delta T from the perfect timing.
            //Here we use the direction of the track given at delta T.
            //You can easily curve all your notes to any trajectory, not just straight lines, by customizing the TrackObjects.
            //Here the target position is found using the track object end position.
            var direction = RhythmClipData.TrackObject.GetNoteDirection(deltaT);
            var distance = deltaT * m_RhythmClipData.RhythmDirector.NoteSpeed;
            var targetPosition = m_RhythmClipData.TrackObject.EndPoint.position;

            //Using those parameters we can easily compute the new position of the note at any time.
            var newPosition = targetPosition + (direction * distance);
            transform.position = newPosition;
        }
        protected override void InvokeNoteTriggerEventMiss()
        {
            if (miss) { return; }

            miss = true;
            secondNote.miss = true;
            m_NoteTriggerEventData.SetMiss();
            InvokeNoteTriggerEvent();
            Player.Instance.OnDamaged(1);
        }
    }
}