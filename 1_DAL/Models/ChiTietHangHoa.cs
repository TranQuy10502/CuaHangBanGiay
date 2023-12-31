﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.Models
{

    [Table("ChiTietSP")]
    public partial class ChiTietHangHoa
    {
        public ChiTietHangHoa()
        {
            HoaDonChiTiets = new HashSet<HoaDonChiTiet>();
        }

        [Key]
        public Guid Id { get; set; }
        [Column("IdSP")]
        public Guid? IdSp { get; set; }
        public Guid? IdQuocGia { get; set; }
        public Guid? IdLoaiGiay { get; set; }
        [Column("IdSizeGiay")]
        public Guid? IdSizeGiay { get; set; }

        public Guid? IdAnh { get; set; }
        public Guid? IdChatLieu { get; set; }

        [Column("NamBH")]
        public int? NamBh { get; set; }
        [StringLength(50)]
        public string? MoTa { get; set; }
        public int? SoLuongTon { get; set; }
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? GiaNhap { get; set; }
        [Column(TypeName = "decimal(20, 0)")]
        public decimal? GiaBan { get; set; }
        public string? MaQRCode { get; set; }
        public int TrangThai { get; set; }

        [ForeignKey(nameof(IdSizeGiay))]
        [InverseProperty(nameof(SizeGiay.ChiTietHangHoas))]
        public virtual SizeGiay IdSizeNavigation { get; set; }

        [ForeignKey(nameof(IdLoaiGiay))]
        [InverseProperty(nameof(LoaiGiay.ChiTietHangHoas))]
        public virtual LoaiGiay IdLoaiGiayNavigation { get; set; }

        [ForeignKey(nameof(IdChatLieu))]
       [InverseProperty(nameof(ChatLieu.ChiTietHangHoas))]
        public virtual ChatLieu IdChatLieuNavigation { get; set; }

        [ForeignKey(nameof(IdAnh))]
        [InverseProperty(nameof(Anh.ChiTietHangHoas))]
        public virtual Anh IdAnhNavigation { get; set; }

        [ForeignKey(nameof(IdQuocGia))]
        [InverseProperty(nameof(QuocGia.HangHoaChiTiet))]

        public virtual QuocGia IdQuocGiaNavigation { get; set; }

        // tham chiếu tới bảng cha
        [ForeignKey(nameof(IdSp))]
        [InverseProperty(nameof(HangHoa.ChiTietSps))]
        public virtual HangHoa IdSpNavigation { get; set; } // Thuộc tính điều hướng tham chiếu
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
    }
}
