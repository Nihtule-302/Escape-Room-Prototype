namespace InventorySystem.Containers
{
    public class StatueItemContainers: ItemContainers
    {
        public ItemType itemType;
        protected override ItemType RequiredItemType => itemType;
    }
}