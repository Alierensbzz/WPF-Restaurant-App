using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.VarlikKatmani.Models
{
    [Table("tblKullanicilar")]
    public class Kullanici
    {
        [Key]
        public string KullaniciAdi { get; set; }
        public string Parola { get; set; }
    }
}
