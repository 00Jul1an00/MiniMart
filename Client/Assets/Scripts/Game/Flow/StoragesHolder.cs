using Zenject;

namespace MiniMart
{
    public class StoragesHolder : Holder<StoragePlace>
    {
        [Inject]
        protected override void Constract(GameFlowManager gameFlowManager)
        {
            base.Constract(gameFlowManager);
        }
    }
}