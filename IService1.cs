using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WcfServiceKaraoke
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
  // 1. bảng LoaiTB
        [OperationContract]
        string InsertLoaiTB(LoaiTB ttLoaiTB);

        [OperationContract]
        DataSet SelectLoaiTB();

        [OperationContract]
        bool DeleteLoaiTB(LoaiTB ttLoaiTB);

        [OperationContract]
        void UpdateLoaiTB(LoaiTB ttLoaiTB);

  // 2. bang thiet bi
        [OperationContract]
        string InsertThietBi(ThietBi ttThietBi);

        [OperationContract]
        DataSet SelectThietBi();

        [OperationContract]
        bool DeleteThietBi(ThietBi ttThietBi);

        [OperationContract]
        void UpdateThietBi(ThietBi ttThietBi);

        [OperationContract]
        DataSet SelectTB_LoaiTB();

        [OperationContract]
        DataSet timKiemTB(ThietBi tkTB);

  // 3. bang chi tiet thiet bi
        [OperationContract]
        string InsertCTThietBi(CTthietBi ttCTThietBi);

        [OperationContract]
        DataSet SelectCTThietBi();

        [OperationContract]
        bool DeleteCTThietBi(CTthietBi ttCTThietBi);

        [OperationContract]
        void UpdateCTThietBi(CTthietBi ttCTThietBi);

  // 4. bảng loại dịch vụ
        [OperationContract]
        string InsertLoaiDV(LoaiDichVu ttLoaiDV);

        [OperationContract]
        DataSet SelectLoaiDV();

        [OperationContract]
        bool DeleteLoaiDV(LoaiDichVu ttLoaiDV);

        [OperationContract]
        void UpdateLoaiDV(LoaiDichVu ttLoaiDV);

        [OperationContract]
        DataSet SelectDV_LoaiDV();
  // 5. bang dich vu
        [OperationContract]
        string InsertDV(DichVu ttDV);

        [OperationContract]
        DataSet SelectDV();

        [OperationContract]
        bool DeleteDV(DichVu ttDV);

        [OperationContract]
        void UpdateDV(DichVu ttDV);

  // 6. bang chi tiet dich vu
        [OperationContract]
        string InsertCTDV(CTDV ttCTDV);

        [OperationContract]
        DataSet SelectCTDV();

        [OperationContract]
        bool DeleteCTDV(CTDV ttCTDV);

        [OperationContract]
        void UpdateCTDV(CTDV ttCTDV);

        [OperationContract]
        DataSet SelectDV_CTDV_PH();

  // 7. bang loai khach hang
        [OperationContract]
        string InsertLoaiKH(LoaiKH ttLoaiKh);

        [OperationContract]
        DataSet SelectLoaiKH();

        [OperationContract]
        bool DeleteLoaiKH(LoaiKH ttLoaiKh);

        [OperationContract]
        void UpdateLoaiKH(LoaiKH ttLoaiKh);

        [OperationContract]
        DataSet SelectKH_LoaiKH();

  // 8. bang khach hang
        [OperationContract]
        string InsertKH(KhachHang ttKh);

        [OperationContract]
        DataSet SelectKH();

        [OperationContract]
        bool DeleteKH(KhachHang ttKh);

        [OperationContract]
        void UpdateKH(KhachHang ttKh);

  // 9. bang nhan vien
        [OperationContract]
        string InsertNV(NhanVien ttNv);

        [OperationContract]
        DataSet SelectNV();

        [OperationContract]
        bool DeleteNV(NhanVien ttNv);

        [OperationContract]
        void UpdateNV(NhanVien ttNv);

        [OperationContract]
        DataSet TimNV(NhanVien ttNv);

        [OperationContract]
        int DoiMatKhau(string matKhauMoi);

        [OperationContract]
        DataSet DangNhap(string user, string password);

        // 10. bang thong bao
        [OperationContract]
        string InsertThongBao(ThongBao ttThongBao);

        [OperationContract]
        DataSet SelectThongBao();

        [OperationContract]
        bool DeleteThongBao(ThongBao ttThongBao);

        [OperationContract]
        void UpdateThongBao(ThongBao ttThongBao);

 // 11. bang hoa don
        [OperationContract]
        string InsertHD(HoaDon ttHD);

        [OperationContract]
        DataSet SelectHD();

        [OperationContract]
        bool DeleteHD(HoaDon ttHD);

        [OperationContract]
        void UpdateHD(HoaDon ttHD);

 // 12. bang phong hat
        [OperationContract]
        string InsertPH(PhongHat ttPhongHat);

        [OperationContract]
        DataSet SelectPH();

        [OperationContract]
        bool DeletePH(PhongHat ttPhongHat);

        [OperationContract]
        void UpdatePH(PhongHat ttPhongHat);

 // 13. bang phieu dat phong
        [OperationContract]
        string InsertPhieuDatPhong(PhieuDatPhong ttPhieuDatPhong);

        [OperationContract]
        DataSet SelectPhieuDatPhong();

        [OperationContract]
        bool DeletePhieuDatPhong(PhieuDatPhong ttPhieuDatPhong);

        [OperationContract]
        void UpdatePhieuDatPhong(PhieuDatPhong ttPhieuDatPhong);


 // 14. bang nhan phong
        [OperationContract]
        string InsertNhanPhong(NhanPhong ttNhanPhong);

        [OperationContract]
        DataSet SelectNhanPhong();

        [OperationContract]
        bool DeleteNhanPhong(NhanPhong ttNhanPhong);

        [OperationContract]
        void UpdateNhanPhong(NhanPhong ttNhanPhong);

    }



    // 1. bang loai tb
    [DataContract]
    public class LoaiTB
    {
        int MaLoaiTB;
        string TenLoaiTB;
        string XuatXu;

        [DataMember]
        public int maLoaiTB
        {
            get { return MaLoaiTB; }
            set { MaLoaiTB = value; }
        }

        [DataMember]
        public string tenLoaiTB
        {
            get { return TenLoaiTB; }
            set { TenLoaiTB = value; }
        }

        [DataMember]
        public string xuatXu
        {
            get { return XuatXu; }
            set { XuatXu = value; }
        }
    }

    // 2. bang thiet bi
    [DataContract]
    public class ThietBi
    {
        int MaTB;
        string TenTB;
        float DonGia;
        int SoLuong;
        int TrangThai;
        int MaLoaiTB;

        [DataMember]
        public int maTB
        {
            get { return MaTB; }
            set { MaTB = value; }
        }

        [DataMember]
        public string tenTB
        {
            get { return TenTB; }
            set { TenTB = value; }
        }

        [DataMember]
        public float donGia
        {
            get { return DonGia; }
            set { DonGia = value; }
        }

        [DataMember]
        public int soLuong
        {
            get { return SoLuong; }
            set { SoLuong = value; }
        }

        [DataMember]
        public int trangThai
        {
           get { return TrangThai; }
           set { TrangThai = value; }
        }

        [DataMember]
        public int maLoaiTB
        {
            get { return MaLoaiTB; }
            set { MaLoaiTB = value; }
        }
    }

    // 3. bang chi tiet thiet bi
    [DataContract]
    public class CTthietBi
    {
        int MaTB;
        int MaPH;
        float DonGia;
        int SoLuong;

        [DataMember]
        public int maTB
        {
            get { return MaTB; }
            set { MaTB = value; }
        }

        [DataMember]
        public int maPH
        {
            get { return MaPH; }
            set { MaPH = value; }
        }

        [DataMember]
        public float donGia
        {
            get { return DonGia; }
            set { DonGia = value; }
        }

        [DataMember]
        public int soLuong
        {
            get { return SoLuong; }
            set { SoLuong = value; }
        }
    }

    // 4. bang loai dich vu
    [DataContract]
    public class LoaiDichVu
    {
        int MaLoaiDV;
        string TenLoaiDV;
        string LoaiDV;

        [DataMember]
        public int maLoaiDV
        {
            get { return MaLoaiDV; }
            set { MaLoaiDV = value; }
        }

        [DataMember]
        public string tenLoaiDV
        {
            get { return TenLoaiDV; }
            set { TenLoaiDV = value; }
        }

        [DataMember]
        public string loaiDV
        {
            get { return LoaiDV; }
            set { LoaiDV = value; }
        }
    }

    // 5. bang dich vu
    [DataContract]
    public class DichVu
    {
        int MaDV;
        string TenDV;
        float DonGia;
        string MoTa;
        int MaLoaiDV;

        [DataMember]
        public int maDV
        {
            get { return MaDV; }
            set { MaDV = value; }
        }

        [DataMember]
        public string tenDV
        {
            get { return TenDV; }
            set { TenDV = value; }
        }

        [DataMember]
        public float donGia
        {
            get { return DonGia; }
            set { DonGia = value; }
        }

        [DataMember]
        public string moTa
        {
            get { return MoTa; }
            set { MoTa = value; }
        }

        [DataMember]
        public int maLoaiDV
        {
            get { return MaLoaiDV; }
            set { MaLoaiDV = value; }
        }

    }

    // 6. bang chi tiet dich vu
    [DataContract]
    public class CTDV
    {
        int MaDV;
        int MaPH;
        float DonGia;
        int SoLuong;

        [DataMember]
        public int maDV
        {
            get { return MaDV; }
            set { MaDV = value; }
        }

        [DataMember]
        public int maPH
        {
            get { return MaPH; }
            set { MaPH = value; }
        }

        [DataMember]
        public float donGia
        {
            get { return DonGia; }
            set { DonGia = value; }
        }

        [DataMember]
        public int soLuong
        {
            get { return SoLuong; }
            set { SoLuong = value; }
        }
    }

    // 7. bang loai khach hang
    [DataContract]
    public class LoaiKH
    {
        int MaLoaiKH;
        string TenLoaiKH;
        int SoLuong;

        [DataMember]
        public int maLoaiKH
        {
            get { return MaLoaiKH; }
            set { MaLoaiKH = value; }
        }

        [DataMember]
        public string tenLoaiKH
        {
            get { return TenLoaiKH; }
            set { TenLoaiKH = value; }
        }

        [DataMember]
        public int soLuong
        {
            get { return SoLuong; }
            set { SoLuong = value; }
        }

    }

    // 8. bang khach hang
    [DataContract]
    public class KhachHang
    {
        int MaKH;
        string TenKH;
        int GioiTinh;
        string DienThoai;
        int MaLoaiKH;

        [DataMember]
        public int maKH
        {
            get { return MaKH; }
            set { MaKH = value; }
        }

        [DataMember]
        public string tenKH
        {
            get { return TenKH; }
            set { TenKH = value; }
        }

        [DataMember]
        public int gioiTinh
        {
            get { return GioiTinh; }
            set { GioiTinh = value; }
        }

        [DataMember]
        public string dienThoai
        {
            get { return DienThoai; }
            set { DienThoai = value; }
        }

        [DataMember]
        public int maLoaiKH
        {
            get { return MaLoaiKH; }
            set { MaLoaiKH = value; }
        }

    }

    // 9. bang nhan vien
    [DataContract]
    public class NhanVien
    {
        int MaNV;
        string TenDN;
        string MatMaDN;
        string QuyenDN;
        string HoTenNV;
        DateTime NgaySinh;
        int GioiTinh;
        string DienThoai;
        string DiaChi;
        float LuongNV;

        [DataMember]
        public int maNV
        {
            get { return MaNV; }
            set { MaNV = value; }
        }

        [DataMember]
        public string tenDN
        {
            get { return TenDN; }
            set { TenDN = value; }
        }

        [DataMember]
        public string matMaDN
        {
            get { return MatMaDN; }
            set { MatMaDN = value; }
        }

        [DataMember]
        public string quyenDN
        {
            get { return QuyenDN; }
            set { QuyenDN = value; }
        }

        [DataMember]
        public string hoTenNV
        {
            get { return HoTenNV; }
            set { HoTenNV = value; }
        }

        [DataMember]
        public DateTime ngaySinh
        {
            get { return NgaySinh; }
            set { NgaySinh = value; }
        }

        [DataMember]
        public int gioiTinh
        {
            get { return GioiTinh; }
            set { GioiTinh = value; }
        }

        [DataMember]
        public string dienThoai
        {
            get { return DienThoai; }
            set { DienThoai = value; }
        }

        [DataMember]
        public string diaChi
        {
            get { return DiaChi; }
            set { DiaChi = value; }
        }

        [DataMember]
        public float luongNV
        {
            get { return LuongNV; }
            set { LuongNV = value; }
        }
    }

    // 10. bang thongn bao
    [DataContract]
    public class ThongBao
    {
        int MaTB;
        string NguoiGui;
        string NguoiNhan;
        DateTime NgayGui;
        DateTime NgayNhan;
        string NoiDungTB;
        bool TrangThaiTb;

        [DataMember]
        public int maThongBao
        {
            get { return MaTB; }
            set { MaTB = value; }
        }

        [DataMember]
        public string nguoiGui
        {
            get { return NguoiGui; }
            set { NguoiGui = value; }
        }

        [DataMember]
        public string nguoiNhan
        {
            get { return NguoiNhan; }
            set { NguoiNhan = value; }
        }

        [DataMember]
        public DateTime ngayGui
        {
            get { return NgayGui; }
            set { NgayGui = value; }
        }

        [DataMember]
        public DateTime ngayNhan
        {
            get { return NgayNhan; }
            set { NgayNhan = value; }
        }

        [DataMember]
        public string noiDungTB
        {
            get { return NoiDungTB; }
            set { NoiDungTB = value; }
        }

        [DataMember]
        public bool trangThaiThongBao
        {
            get { return TrangThaiTb; }
            set { TrangThaiTb = value; }
        }

    }

    // 11. bang hoa don
    [DataContract]
    public class HoaDon
    {
        int MaHD;
        int MaPH;
        float ThanhTien;
        float TongTien;
        bool TrangThai;
        DateTime NgayLap;
        string ThangLap;
        string NamLap;

        [DataMember]
        public int maHD
        {
            get { return MaHD; }
            set { MaHD = value; }
        }

        [DataMember]
        public int maPH
        {
            get { return MaPH; }
            set { MaPH = value; }
        }

        [DataMember]
        public float thanhTien
        {
            get { return ThanhTien; }
            set { ThanhTien = value; }
        }

        [DataMember]
        public float tongTien
        {
            get { return TongTien; }
            set { TongTien = value; }
        }

        [DataMember]
        public bool trangThai
        {
            get { return TrangThai; }
            set { TrangThai = value; }
        }

        [DataMember]
        public DateTime ngayLap
        {
            get { return NgayLap; }
            set { NgayLap = value; }
        }

        [DataMember]
        public string thangLap
        {
            get { return ThangLap; }
            set { ThangLap = value; }
        }

        [DataMember]
        public string namLap
        {
            get { return NamLap; }
            set { NamLap = value; }
        }


    }

    //12. bang phong hat
    [DataContract]
    public class PhongHat
    {
        int MaPH;
        string TenPH;
        int TrangThai;
        DateTime NgayVao;
        TimeSpan GioVao;
        TimeSpan GioRa;

        [DataMember]
        public int maPH
        {
            get { return MaPH; }
            set { MaPH = value; }
        }

        [DataMember]
        public string tenPH
        {
            get { return TenPH; }
            set { TenPH = value; }
        }

        [DataMember]
        public int trangThai
        {
            get { return TrangThai; }
            set { TrangThai = value; }
        }

        [DataMember]
        public DateTime ngayVao
        {
            get { return NgayVao; }
            set { NgayVao = value; }
        }

        [DataMember]
        public TimeSpan gioVao
        {
            get { return GioVao; }
            set { GioVao = value; }
        }

        [DataMember]
        public TimeSpan gioRa
        {
            get { return GioRa; }
            set { GioRa = value; }
        }

    }

    // 13. bang phieu dat phong
    [DataContract]
    public class PhieuDatPhong
    {
        int SoPD;
        string NgayDat;
        int GioDat;
        int MaPH;
        int MaKH;

        [DataMember]
        public int soPD
        {
            get { return SoPD; }
            set { SoPD = value; }
        }

        [DataMember]
        public string ngayDat
        {
            get { return NgayDat; }
            set { NgayDat = value; }
        }

        [DataMember]
        public int gioDat
        {
            get { return GioDat; }
            set { GioDat = value; }
        }

        [DataMember]
        public int maKH
        {
            get { return MaKH; }
            set { MaKH = value; }
        }

        [DataMember]
        public int maPH
        {
            get { return maPH; }
            set { MaPH = value; }
        }
    }

    // 14. bang nhan phong
    [DataContract]
    public class NhanPhong
    {
        int MaNP;
        string TenKH;
        DateTime NgayNhan;
        TimeSpan GioNhan;
        int MaPH;
        int SoLuongNguoi;
        string SoDienThoai;

        [DataMember]
        public int maNP
        {
            get { return MaNP; }
            set { MaNP = value; }
        }

        [DataMember]
        public string tenKH
        {
            get { return TenKH; }
            set { TenKH = value; }
        }

        [DataMember]
        public DateTime ngayNhan
        {
            get { return NgayNhan; }
            set { NgayNhan = value; }
        }

        [DataMember]
        public TimeSpan gioNhan
        {
            get { return GioNhan; }
            set { GioNhan = value; }
        }

        [DataMember]
        public int maPH
        {
            get { return MaPH; }
            set { MaPH = value; }
        }

        [DataMember]
        public int soLuongNguoi
        {
            get { return SoLuongNguoi; }
            set { SoLuongNguoi = value; }
        }

        [DataMember]
        public string soDienThoai
        {
            get { return SoDienThoai; }
            set { SoDienThoai = value; }
        }
    }
}
