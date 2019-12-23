using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystm.Api.Models
{
    public class Peminjaman
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_transaksi { get; set; }
        [Required]
        public int Id_books { get; set; }
        [Required]
        public int Id_member { get; set; }
        [Required]
        public DateTime Tgl_pinjam { get; set; }
        [Required]
        public DateTime Tgl_pengembalian { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}
