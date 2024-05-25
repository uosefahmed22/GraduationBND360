using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Core.Models.Content.Favorite
{
    public class FavoriteModelForCraftsmen
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CraftsmanId { get; set; }
    }
}
