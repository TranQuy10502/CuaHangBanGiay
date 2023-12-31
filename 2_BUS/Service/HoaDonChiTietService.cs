﻿using _1.DAL.IRepositories;
using _1.DAL.IRepostiories;
using _1.DAL.Repostiores;
using _1_DAL.Models;
using _2_BUS.IService;
using _2_BUS.ViewModels;

namespace _2_BUS.Service
{
    public class HoaDonChiTietService : IHoaDonChiTietService
    {
        IreceiptDetailRepository _IreceiptDetailRepository;
        IreceiptRepository _HoaDonRepos;
        IProductDetailRepository _IProductDetailRepository;
        IProductRepository _ProductRepository;
        public HoaDonChiTietService()
        {
            _IProductDetailRepository = new ProductDetailRepositores();
            _ProductRepository = new ProductRepositores();
            _IreceiptDetailRepository = new ReceiptDetailRepositores();
            _HoaDonRepos = new ReceiptRepositores();
        }

        public List<HoaDonChiTietViewModel> GetAllHoaDonDB()
        {
            return (from a in _IreceiptDetailRepository.GetAll()
                    join b in _HoaDonRepos.getAllReceipt() on a.IdHoaDon equals b.Id
                    select new HoaDonChiTietViewModel
                    {

                        IdHoaDon = a.IdHoaDon,
                        IdChiTietSp = a.IdChiTietSp,
                        SoLuong = a.SoLuong,
                        ThanhTien = a.ThanhTien,
                        TrangThai = a.TrangThai,
                    }).ToList();

        }

        public List<SanPhamTrongHoaDonViewModels> GetAllProductInReceipt()
        {
            return (from a in _ProductRepository.getAll()
                    join b in _IProductDetailRepository.getAll() on a.Id equals b.IdSp
                    join c in _IreceiptDetailRepository.GetAll() on b.Id equals c.IdChiTietSp
                    join d in _HoaDonRepos.getAllReceipt() on c.IdHoaDon equals d.Id
                    select new SanPhamTrongHoaDonViewModels
                    {
                        IdsP = a.Id,
                        MaSP = a.Ma,
                        TenSp = a.Ten,
                        SoLuong = c.SoLuong,
                        IdSpCt = b.Id,
                        DonGia = b.GiaBan,
                        IdHoaDon = c.IdHoaDon,
                        ThanhTien = b.GiaBan * c.SoLuong
                    }).ToList();
        }

        public bool SuaHoaDonChiTiet(HoaDonChiTietViewModel Hoadons)
        {
            HoaDonChiTiet hdct = _IreceiptDetailRepository.GetAll().FirstOrDefault(p => p.IdHoaDon == Hoadons.IdHoaDon);
            hdct.GiamGia = Hoadons.GiamGia;
            hdct.SoLuong = Hoadons.SoLuong;
            hdct.ThanhTien = Hoadons.ThanhTien;
            hdct.TrangThai = Hoadons.TrangThai;
            if (_IreceiptDetailRepository.update(hdct)) return true;
            return false;
        }


        public bool ThemHoaDonChiTiet(HoaDonChiTietThemViewModel Hoadons)
        {
            HoaDonChiTiet hdct = new HoaDonChiTiet();
            hdct.IdHoaDon = Hoadons.IdHoaDon;
            hdct.GiamGia = Hoadons.GiamGia;
            hdct.IdChiTietSp = Hoadons.IdChiTietSp;
            hdct.SoLuong = Hoadons.SoLuong;
            hdct.ThanhTien = Hoadons.ThanhTien;
            hdct.TrangThai = Hoadons.TinhTrang;
            if (_IreceiptDetailRepository.add(hdct)) return true;
            return false;
        }

        public bool XoaHoaDonChiTiet(Guid Hoadonld)
        {
            if (_IreceiptDetailRepository.remove(Hoadonld)) return true;
            return false;
        }
        public List<HoaDonChiTietViewModel> timkiemhdtheoid(Guid id)
        {
            return (from a in _ProductRepository.getAll()
                    join b in _IProductDetailRepository.getAll() on a.Id equals b.IdSp
                    join c in _IreceiptDetailRepository.GetAll() on b.Id equals c.IdChiTietSp
                    join d in _HoaDonRepos.getAllReceipt() on c.IdHoaDon equals d.Id
                    where d.Id == id
                    select new HoaDonChiTietViewModel
                    {
                        IdChiTietSp = a.Id,
                        Name = a.Ten,
                        IdHoaDon = d.Id,
                        SoLuong = c.SoLuong,
                        DonGia = b.GiaBan,
                        TrangThai = Convert.ToInt32(d.TinhTrang),
                        GiamGia = c.GiamGia,
                        ThanhTien = b.GiaBan * c.SoLuong
                    }).ToList();

        }

        public bool XoaSpTrongHoaDonChiTiet(Guid Id, Guid IdHoaDon)
        {
            if (_IreceiptDetailRepository.removeSP(Id, IdHoaDon)) return true;
            return false;
        }
    }
}
