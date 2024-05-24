using Zenject;

namespace MiniMart
{
    public class ProdactionsHolder : Holder<ProdactionPlace>
    {
        [Inject]
        protected override void Constract(GameFlowManager gameFlowManager)
        {
            base.Constract(gameFlowManager);

            foreach (var prodaction in _itemsInHolder)
            {
                prodaction.InitDefault();
                gameFlowManager.AddUpdateble(prodaction);
            }
        }
    }
}