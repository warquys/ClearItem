using MEC;
using Synapse.Api;
using Synapse.Api.Enum;
using Synapse.Api.Events.SynapseEventArguments;
using Synapse.Api.Items;
using System.Collections.Generic;

namespace ClearItem
{
    public class EventHandler
    {

        #region Properties & Variables
        Dictionary<SynapseItem, CoroutineHandle> ItemsCoroutine = new Dictionary<SynapseItem, CoroutineHandle>();
        #endregion

        #region Constructor & Destructor
        public EventHandler()
        {
            Synapse.Api.Events.EventHandler.Get.Player.PlayerDropItemEvent += OnDropItem;
            Synapse.Api.Events.EventHandler.Get.Player.PlayerPickUpItemEvent += OnPickup;
        }
        #endregion

        #region Methods
        private void CoroutineStartFor(SynapseItem item)
        {
            CoroutineStopFor(item);
            CoroutineHandle coroutine = Timing.RunCoroutine(DeleteAfterTime(item));
            ItemsCoroutine.Add(item, coroutine);
        }
        private bool CoroutineStopFor(SynapseItem item)
        {
            if (ItemsCoroutine.ContainsKey(item))
            {
                Timing.KillCoroutines(ItemsCoroutine[item]);
                return ItemsCoroutine.Remove(item);
            }
            return false;
        }

        private IEnumerator<float> DeleteAfterTime(SynapseItem item)
        {
            yield return Timing.WaitForSeconds(Plugin.Instance.Config.TimeBeforeDespawn);

            if (item is null) yield break;

            if (item.State == ItemState.Map)
                item.Despawn();


        }
        #endregion

        #region Events

        private void OnDropItem(PlayerDropItemEventArgs ev)
        {
            CoroutineStartFor(ev.Item);
        }

        private void OnPickup(PlayerPickUpItemEventArgs ev)
        {
            CoroutineStopFor(ev.Item);
        }
        #endregion
    }
}