using RestaurantApp.VarlikKatmani.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.VarlikKatmani.Models
{
    [Table("tblUrunler")]
    public class Urun : BaseEntity
    {
        public string Ad { get; set; }
        
        [DataType("MONEY")]
        public decimal Fiyat { get; set; }
        public int KategoriId { get; set; }

        [ForeignKey(nameof(KategoriId))]
        public Kategori Kategori { get; set; }

    }
}
