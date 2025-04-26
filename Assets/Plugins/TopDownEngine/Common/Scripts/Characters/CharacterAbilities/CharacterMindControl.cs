using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;

namespace MoreMountains.TopDownEngine // you might want to use your own namespace here
{
    [AddComponentMenu("TopDown Engine/Character/Abilities/Character Mind Control")]
    public class CharacterMindControl : CharacterAbility
    {
        /// declare your parameters here
        public float MindControlDuration = 10f;
        public MMFeedbacks MindControlMMFeedbacks;
        public bool IsMindControlled { get; private set; }
        private AIDecisionDetectTargetRadius2D _aiDetect;

        /// <summary>
        /// Here you should initialize our parameters
        /// </summary>
        protected override void Initialization()
        {
            base.Initialization();
            _aiDetect = GetComponent<AIDecisionDetectTargetRadius2D>();
            MindControlMMFeedbacks?.Initialization(this.gameObject);
        }

        /// <summary>
        /// Every frame, we check if we're crouched and if we still should be
        /// </summary>
        public override void ProcessAbility()
        {
            base.ProcessAbility();
        }

        /// <summary>
        /// Called at the start of the ability's cycle, this is where you'll check for input
        /// </summary>
        public void ApplyMindControl()
        {
            if (IsMindControlled) return;
            StartCoroutine(MindControlRoutine());
        }

        private IEnumerator MindControlRoutine()
        {
            IsMindControlled = true;
            _aiDetect.TargetLayer = LayerMask.GetMask("Enemies");
            _aiDetect.Radius = 10;
            MindControlMMFeedbacks?.PlayFeedbacks(this.transform.position);

            yield return new WaitForSeconds(MindControlDuration);

            _aiDetect.Radius = 5;
            _aiDetect.TargetLayer = LayerMask.GetMask("Player");
            IsMindControlled = false;
        }
    }
}