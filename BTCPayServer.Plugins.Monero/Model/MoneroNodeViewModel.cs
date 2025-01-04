using System.ComponentModel.DataAnnotations;

namespace BTCPayServer.Plugins.Monero.Model
{
    public enum MoneroNodeType
    {
        Internal,
        Custom
    }

    public class MoneroNodeViewModel
    {
        public MoneroNodeType MoneroNodeType { get; set; }
        public string StoreId { get; set; }
        public string CryptoCode { get; set; }
        public bool CanUseInternalNode { get; set; }
        public bool SkipPortTest { get; set; }

        [Display(Name = "Enabled")]
        public bool Enabled { get; set; } = true;

        [Display(Name = "Connection string")]
        public string ConnectionString { get; set; }
    }
}
