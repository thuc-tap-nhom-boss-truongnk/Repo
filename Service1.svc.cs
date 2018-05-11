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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        string strQuery = @"Data Source=DESKTOP-SN5A3KJ\SQLEXPRESS;Initial Catalog=IKaraokeDB;Persist Security Info=True;User ID=sa;Password=1234567";
        // 1. bang loai thiet bi
        public DataSet SelectLoaiTB()
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from LoaiThietBi", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }

        public void UpdateLoaiTB(LoaiTB ttloaiTB)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("update LoaiThietBi set TenLoaiTB=@tenLoaiTB, XuatXu=@xuatXu where MaLoaiTB=@idLoaiTB", con);
            cmd.Parameters.AddWithValue("@idLoaiTB", ttloaiTB.maLoaiTB);
            cmd.Parameters.AddWithValue("@tenLoaiTB", ttloaiTB.tenLoaiTB);
            cmd.Parameters.AddWithValue("@xuatXu", ttloaiTB.xuatXu);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public bool DeleteLoaiTB(LoaiTB ttloaiTB)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from LoaiThietBi where MaLoaiTB=@idLoaiTB", con);
            cmd.Parameters.AddWithValue("@idLoaiTB", ttloaiTB.maLoaiTB);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public string InsertLoaiTB(LoaiTB ttLoaiTB)
        {
            string Message;
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into LoaiThietBi(TenLoaiTB,XuatXu) values(@tenLoaiTB,@xuatXu)", con);
            cmd.Parameters.AddWithValue("@tenLoaiTB", ttLoaiTB.tenLoaiTB);
            cmd.Parameters.AddWithValue("@xuatXu", ttLoaiTB.xuatXu);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = ttLoaiTB.tenLoaiTB + "them thanh cong";
            }
            else
            {
                Message = ttLoaiTB.tenLoaiTB + "them khong thanh cong";
            }
            con.Close();
            return Message;
        }

       

        // 2. bang thiet bi
        public DataSet SelectTB_LoaiTB()
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("select MaTB, TenTB, DonGia, SoLuong, TrangThai, TenLoaiTB, XuatXu, LoaiThietBi.MaLoaiTB  from ThietBi,LoaiThietBi where ThietBi.MaLoaiTB = LoaiThietBi.MaLoaiTB", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }
        public string InsertThietBi(ThietBi ttThietBi)
        {
            string Message;
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into ThietBi(TenTB,DonGia,SoLuong,TrangThai,MaLoaiTB) values(@tenTB,@donGia,@soLuong,@trangThai,@maLoaiTB)", con);
            cmd.Parameters.AddWithValue("@tenTB", ttThietBi.tenTB);
            cmd.Parameters.AddWithValue("@donGia", ttThietBi.donGia);
            cmd.Parameters.AddWithValue("@soluong", ttThietBi.soLuong);
            cmd.Parameters.AddWithValue("@trangThai", ttThietBi.trangThai);
            cmd.Parameters.AddWithValue("@maLoaiTB", ttThietBi.maLoaiTB);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = ttThietBi.tenTB + "them thanh cong";
            }
            else
            {
                Message = ttThietBi.tenTB + "them khong thanh cong";
            }
            con.Close();
            return Message;
        }

        public DataSet SelectThietBi()
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from ThietBi", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }

        public bool DeleteThietBi(ThietBi ttThietBi)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from ThietBi where MaTB=@idTB", con);
            cmd.Parameters.AddWithValue("@idTB", ttThietBi.maTB);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public void UpdateThietBi(ThietBi ttThietBi)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("update ThietBi set TenTB=@tenTB, DonGia=@donGia, SoLuong=@soLuong, TrangThai=@trangthai, MaLoaiTB=@maLoaiTB where MaTB=@idTB", con);
            cmd.Parameters.AddWithValue("@idTB", ttThietBi.maTB);
            cmd.Parameters.AddWithValue("@tenTB", ttThietBi.tenTB);
            cmd.Parameters.AddWithValue("@donGia", ttThietBi.donGia);
            cmd.Parameters.AddWithValue("@soluong", ttThietBi.soLuong);
            cmd.Parameters.AddWithValue("@trangThai", ttThietBi.trangThai);
            cmd.Parameters.AddWithValue("@maLoaiTB", ttThietBi.maLoaiTB);
            cmd.ExecuteNonQuery();
            con.Close();
        }

       

       // 3. bang chi tiet thiet bi
       public string InsertCTThietBi(CTthietBi ttCTThietBi)
        {
            string Message;
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into CTThietBi(MaTB,MaPH,DonGia,SoLuong) values(@maTB,@idPH,@donGia,@soLuong)", con);
            cmd.Parameters.AddWithValue("@maTB", ttCTThietBi.maTB);
            cmd.Parameters.AddWithValue("@maPH", ttCTThietBi.maPH);
            cmd.Parameters.AddWithValue("@tenTB", ttCTThietBi.maPH);
            cmd.Parameters.AddWithValue("@donGia", ttCTThietBi.donGia);
            cmd.Parameters.AddWithValue("@soluong", ttCTThietBi.soLuong);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = "thiet bi co ma" + ttCTThietBi.maTB + "them thanh cong";
            }
            else
            {
                Message = "thiet bi co ma" + ttCTThietBi.maTB + "them khong thanh cong";
            }
            con.Close();
            return Message;
        }

        public DataSet SelectCTThietBi()
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from CTThietBi", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }

        public bool DeleteCTThietBi(CTthietBi ttCTThietBi)
        {
            SqlConnection con = new SqlConnection(strQuery);
            SqlCommand cmd = new SqlCommand("delete from CTThietBi where MaTB=@idTB", con);
            cmd.Parameters.AddWithValue("@idTB", ttCTThietBi.maTB);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public void UpdateCTThietBi(CTthietBi ttCTThietBi)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("update CTThietBi set MaPH=@MaPH, DonGia=@donGia, SoLuong=@soLuong where MaTB=@idTB", con);
            cmd.Parameters.AddWithValue("@iTB", ttCTThietBi.maTB);
            cmd.Parameters.AddWithValue("@tenTB", ttCTThietBi.maPH);
            cmd.Parameters.AddWithValue("@donGia", ttCTThietBi.donGia);
            cmd.Parameters.AddWithValue("@soluong", ttCTThietBi.soLuong);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // 4. bang loai dich vu
        public string InsertLoaiDV(LoaiDichVu ttLoaiDV)
        {
            string Message;
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into LoaiDichVu(TenLoaiDV,LoaiDV) values(@tenLoaiDV,@loaiDV)", con);
            cmd.Parameters.AddWithValue("@tenLoaiDV", ttLoaiDV.tenLoaiDV);
            cmd.Parameters.AddWithValue("@loaiDV", ttLoaiDV.loaiDV);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = ttLoaiDV.tenLoaiDV + "them thanh cong";
            }
            else
            {
                Message = ttLoaiDV.tenLoaiDV + "them khong thanh cong";
            }
            con.Close();
            return Message;
        }

        public DataSet SelectLoaiDV()
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from LoaiDichVu", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }

        public bool DeleteLoaiDV(LoaiDichVu ttLoaiDV)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from LoaiDichVu where MaLoaiDV=@idLoaiDV", con);
            cmd.Parameters.AddWithValue("@idLoaiDV", ttLoaiDV.maLoaiDV);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public void UpdateLoaiDV(LoaiDichVu ttLoaiDV)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("update LoaiDichVu set TenLoaiDV=@tenLoaiDV, LoaiDV=@loaiDV where MaLoaiDV=@idLoaiDV", con);
            cmd.Parameters.AddWithValue("@idLoaiDV", ttLoaiDV.maLoaiDV);
            cmd.Parameters.AddWithValue("@tenLoaiDV", ttLoaiDV.tenLoaiDV);
            cmd.Parameters.AddWithValue("@loaiDV", ttLoaiDV.loaiDV);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataSet SelectDV_LoaiDV()
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("select MaDV, TenDV, DonGia, MoTa, TenLoaiDV, LoaiDichVu.MaLoaiDV from LoaiDichVu, DichVu where LoaiDichVu.MaLoaiDV = DichVu.MaLoaiDV", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }


        

        public DataSet SelectDV_CTDV_PH()
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("select CTDichVu.MaDV, CTDichVu.MaPH, TenDV, TenPH, CTDichVu.DonGia, SoLuong from DichVu, CTDichVu, PhongHat where DichVu.MaDV = CTDichVu.MaDV and PhongHat.MaPH = CTDichVu.MaPH", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }

        // 5. bang dich vu
        public string InsertDV(DichVu ttDV)
        {
            string Message;
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into DichVu(TenDV,DonGia,MoTa,MaLoaiDV) values(@tenDV,@donGia,@moTa,@maLoaiDV)", con);
            cmd.Parameters.AddWithValue("@tenDV", ttDV.tenDV);
            cmd.Parameters.AddWithValue("@donGia", ttDV.donGia);
            cmd.Parameters.AddWithValue("@moTa", ttDV.moTa);
            cmd.Parameters.AddWithValue("@maLoaiDV", ttDV.maLoaiDV);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = ttDV.tenDV + "them thanh cong";
            }
            else
            {
                Message = ttDV.tenDV + "them khong thanh cong";
            }
            con.Close();
            return Message;
        }

        public DataSet SelectDV()
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from DichVu", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }

        public bool DeleteDV(DichVu ttDV)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from DichVu where MaDV=@idDV", con);
            cmd.Parameters.AddWithValue("@idDV", ttDV.maDV);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public void UpdateDV(DichVu ttDV)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("update DichVu set TenDV=@tenDV, DonGia=@donGia, MoTa=@moTa, MaLoaiDV=@maLoaiDV  where MaDV=@idDV", con);
            cmd.Parameters.AddWithValue("@idDV", ttDV.maDV);
            cmd.Parameters.AddWithValue("@tenDV", ttDV.tenDV);
            cmd.Parameters.AddWithValue("@donGia", ttDV.donGia);
            cmd.Parameters.AddWithValue("@moTa", ttDV.moTa);
            cmd.Parameters.AddWithValue("@maLoaiDV", ttDV.maLoaiDV);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // 6. bang chi tiet dich vu
        public string InsertCTDV(CTDV ttCTDV)
        {
            string Message;
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into CTDichVu(MaDV,MaPH,DonGia,SoLuong) values(@idDV,@maPH,@donGia,@soLuong)", con);
            cmd.Parameters.AddWithValue("@idDV", ttCTDV.maDV);
            cmd.Parameters.AddWithValue("@maPH", ttCTDV.maPH);
            cmd.Parameters.AddWithValue("@donGia", ttCTDV.donGia);
            cmd.Parameters.AddWithValue("@soLuong", ttCTDV.soLuong);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = "dich vu co ma la " + ttCTDV.maDV + " duoc them thanh cong";
            }
            else
            {
                Message = "dich vu co ma la " + ttCTDV.maDV + " them khong thanh cong";
            }
            con.Close();
            return Message;
        }

        public DataSet SelectCTDV()
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from CTDichVu", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }

        public bool DeleteCTDV(CTDV ttCTDV)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from CTDichVu where MaDV=@idDV and MaPH=@idPH", con);
            cmd.Parameters.AddWithValue("@idDV", ttCTDV.maDV);
            cmd.Parameters.AddWithValue("@idPH", ttCTDV.maPH);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public void UpdateCTDV(CTDV ttCTDV)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("update CTDichVu set DonGia=@donGia, SoLuong=@soLuong  where  MaPH=@maPH and MaDV=@idDV", con);
            cmd.Parameters.AddWithValue("@idDV", ttCTDV.maDV);
            cmd.Parameters.AddWithValue("@maPH", ttCTDV.maPH);
            cmd.Parameters.AddWithValue("@donGia", ttCTDV.donGia);
            cmd.Parameters.AddWithValue("@soLuong", ttCTDV.soLuong);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // 12. bang phong hat
        public string InsertPH(PhongHat ttPhongHat)
        {
            string Message;
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into PhongHat(TenPH,TrangThai) values(@tenPH,@trangThai)", con);
            cmd.Parameters.AddWithValue("@tenPH", ttPhongHat.tenPH);
            cmd.Parameters.AddWithValue("@trangThai", ttPhongHat.trangThai);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = "thong tin phong hat duoc them thanh cong";
            }
            else
            {
                Message = "thong tin phong hat them khong thanh cong";
            }
            con.Close();
            return Message;
        }

        public DataSet SelectPH()
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from PhongHat", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }

        public bool DeletePH(PhongHat ttPhongHat)
        {

            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from PhongHat where MaPH=@idPH", con);
            cmd.Parameters.AddWithValue("@idPH", ttPhongHat.maPH);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public void UpdatePH(PhongHat ttPhongHat)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("update PhongHat set TenPH=@tenPH, TrangThai=@trangThai, NgayVao=@ngayVao, GioVao=@gioVao, GioRa=@gioRa  where MaPH=@idPH", con);
            cmd.Parameters.AddWithValue("@idPH", ttPhongHat.maPH);
            cmd.Parameters.AddWithValue("@tenPH", ttPhongHat.tenPH);
            cmd.Parameters.AddWithValue("@trangThai", ttPhongHat.trangThai);
            cmd.Parameters.AddWithValue("@ngayVao", ttPhongHat.ngayVao);
            cmd.Parameters.AddWithValue("@gioVao", ttPhongHat.gioVao);
            cmd.Parameters.AddWithValue("@gioRa", ttPhongHat.gioRa);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // 7. bang loai khach hang
        public string InsertLoaiKH(LoaiKH ttLoaiKh)
        {
            string Message;
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into LoaiKhachHang(TenLoaiKH,SoLuong) values(@tenLoaiKH,@soLuong)", con);
            cmd.Parameters.AddWithValue("@tenLoaiKH", ttLoaiKh.tenLoaiKH);
            cmd.Parameters.AddWithValue("@soLuong", ttLoaiKh.soLuong);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = ttLoaiKh.tenLoaiKH + " duoc them thanh cong";
            }
            else
            {
                Message = ttLoaiKh.tenLoaiKH + " them khong thanh cong";
            }
            con.Close();
            return Message;
        }

        public DataSet SelectLoaiKH()
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from LoaiKhachHang", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }

        public bool DeleteLoaiKH(LoaiKH ttLoaiKh)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from LoaiKhachHang where MaLoaiKH=@idLoaiKH", con);
            cmd.Parameters.AddWithValue("@idLoaiKH", ttLoaiKh.maLoaiKH);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public void UpdateLoaiKH(LoaiKH ttLoaiKh)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("update LoaiKhachHang set SoLuong=@soLuong  where MaLoaiKH=@idLoaiKH", con);
            cmd.Parameters.AddWithValue("@idLoaiKH", ttLoaiKh.maLoaiKH);
            cmd.Parameters.AddWithValue("@tenLoaiKH", ttLoaiKh.tenLoaiKH);
            cmd.Parameters.AddWithValue("@soLuong", ttLoaiKh.soLuong);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataSet SelectKH_LoaiKH()
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("select MaKH, TenKH,GT,DienThoai,TenLoaiKH, KhachHang.MaLoaiKH from KhachHang, LoaiKhachHang where KhachHang.MaLoaiKH = LoaiKhachHang.MaLoaiKH", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }

        // 8. bang khach hang
        public string InsertKH(KhachHang ttKh)
        {
            string Message;
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into KhachHang(TenKH,GT,DienThoai,MaLoaiKH) values(@tenKH,@gioiTinh,@dienThoai,@maLoaiKH)", con);
            cmd.Parameters.AddWithValue("@tenKH", ttKh.tenKH);
            cmd.Parameters.AddWithValue("@gioiTinh", ttKh.gioiTinh);
            cmd.Parameters.AddWithValue("@dienThoai", ttKh.dienThoai);
            cmd.Parameters.AddWithValue("@maLoaiKH", ttKh.maLoaiKH);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = ttKh.tenKH + " duoc them thanh cong";
            }
            else
            {
                Message = ttKh.tenKH + " them khong thanh cong";
            }
            con.Close();
            return Message;
        }

        public DataSet SelectKH()
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from KhachHang", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }

        public bool DeleteKH(KhachHang ttKh)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from KhachHang where MaKH=@idKH", con);
            cmd.Parameters.AddWithValue("@idKH", ttKh.maKH);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public void UpdateKH(KhachHang ttKh)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("update KhachHang set TenKH=@tenKH, GT=@gioiTinh, DienThoai=@dienThoai, MaLoaiKH=@maLoaiKH  where MaKH=@idKH", con);
            cmd.Parameters.AddWithValue("@idKH", ttKh.maKH);
            cmd.Parameters.AddWithValue("@tenKH", ttKh.tenKH);
            cmd.Parameters.AddWithValue("@gioiTinh", ttKh.gioiTinh);
            cmd.Parameters.AddWithValue("@dienThoai", ttKh.dienThoai);
            cmd.Parameters.AddWithValue("@maLoaiKH", ttKh.maLoaiKH);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // 9. bang nhan vien
        public string InsertNV(NhanVien ttNv)
        {
            string Message;
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into NhanVien(TenDN,MatMaDN,QuyenDN,HoTenNV,NgaySinh,GT,DienThoai,DiaChi,LuongNV) values(@tenDN,@matKhauDN,@quyenDN,@hoTenNV,@ngaySinh,@gioiTinh,@dienThoai,@diaChi,@luongNV)", con);
            cmd.Parameters.AddWithValue("@tenDN", ttNv.tenDN);
            cmd.Parameters.AddWithValue("@matKhauDN", ttNv.matMaDN);
            cmd.Parameters.AddWithValue("@quyenDN", ttNv.quyenDN);
            cmd.Parameters.AddWithValue("@hoTenNV", ttNv.hoTenNV);
            cmd.Parameters.AddWithValue("@ngaySinh", ttNv.ngaySinh);
            cmd.Parameters.AddWithValue("@gioiTinh", ttNv.gioiTinh);
            cmd.Parameters.AddWithValue("@dienThoai", ttNv.dienThoai);
            cmd.Parameters.AddWithValue("@diaChi", ttNv.diaChi);
            cmd.Parameters.AddWithValue("@luongNV", ttNv.luongNV);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = ttNv.hoTenNV + " duoc them thanh cong";
            }
            else
            {
                Message = ttNv.hoTenNV + " them khong thanh cong";
            }
            con.Close();
            return Message;
        }

        public DataSet SelectNV()
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from NhanVien", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }

        public bool DeleteNV(NhanVien ttNv)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from NhanVien where MaNV=@idNV", con);
            cmd.Parameters.AddWithValue("@idNV", ttNv.maNV);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public void UpdateNV(NhanVien ttNv)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("update NhanVien set TenDN=@tenDN, QuyenDN=@quyenDN, HoTenNV=@hoTenNV, NgaySinh=@ngaySinh, GT=@gioiTinh, DienThoai=@dienThoai, DiaChi=@diaChi, LuongNV=@luongNV  where MaNV=@idNV", con);
            cmd.Parameters.AddWithValue("@idNV", ttNv.maNV);
            cmd.Parameters.AddWithValue("@tenDN", ttNv.tenDN);
            cmd.Parameters.AddWithValue("@quyenDN", ttNv.quyenDN);
            cmd.Parameters.AddWithValue("@hoTenNV", ttNv.hoTenNV);
            cmd.Parameters.AddWithValue("@ngaySinh", ttNv.ngaySinh);
            cmd.Parameters.AddWithValue("@gioiTinh", ttNv.gioiTinh);
            cmd.Parameters.AddWithValue("@dienThoai", ttNv.dienThoai);
            cmd.Parameters.AddWithValue("@diaChi", ttNv.diaChi);
            cmd.Parameters.AddWithValue("@luongNV", ttNv.luongNV);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataSet DangNhap(string user, string password)
        {
            NhanVien nv = new NhanVien();
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("select TenDN, MatMaDN from NhanVien where TenDN=@user and MatMaDN=@password", con);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@password", password);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            return ds;
            con.Close();
        }

        public DataSet TimNV(NhanVien ttNv)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from NhanVien where MaNV=@idNV");
            cmd.Parameters.AddWithValue("@idNV", ttNv.maNV);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }
        
        public int DoiMatKhau(string matKhauMoi)
        {
            NhanVien ttNV = new NhanVien();
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("update NhanVien set MatMaDN=@matMaDN where MaNV=@maNV", con);
            cmd.Parameters.AddWithValue("@maNV", ttNV.maNV);
            cmd.Parameters.AddWithValue("@matMaNV", ttNV.matMaDN);
            int result = cmd.ExecuteNonQuery();
            if(result == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
            con.Close();
        }
        // 10. bang thong bao
        public string InsertThongBao(ThongBao ttThongBao)
        {
            string Message;
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into ThongBao(MaTB,NguoiGui,NguoiNhan,NgayGui,NgayNhan,NoiDungTB,TrangThaiTB) values(@idTB,@nguoiGui,@nguoiNhan,@ngayGui,@ngayNhan,@noiDungTB,@trangThaiTB)", con);
            cmd.Parameters.AddWithValue("@idTB", ttThongBao.maThongBao);
            cmd.Parameters.AddWithValue("@nguoiGui", ttThongBao.nguoiGui);
            cmd.Parameters.AddWithValue("@nguoiNhan", ttThongBao.nguoiNhan);
            cmd.Parameters.AddWithValue("@ngayGui", ttThongBao.ngayGui);
            cmd.Parameters.AddWithValue("@ngayNhan", ttThongBao.ngayNhan);
            cmd.Parameters.AddWithValue("@noiDungTB", ttThongBao.noiDungTB);
            cmd.Parameters.AddWithValue("@trangThaiTB", ttThongBao.trangThaiThongBao);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message =  "thong bao duoc them thanh cong";
            }
            else
            {
                Message = "thong bao them khong thanh cong";
            }
            con.Close();
            return Message;
        }

        public DataSet SelectThongBao()
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from ThongBao", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }

        public bool DeleteThongBao(ThongBao ttThongBao)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from ThongBao where MaTB=@idTB", con);
            cmd.Parameters.AddWithValue("@idTB", ttThongBao.maThongBao);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public void UpdateThongBao(ThongBao ttThongBao)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("update ThongBao set NguoiGui=@nguoiGui, NguoiNhan=@nguoiNhan, NgayGui=@ngayGui, NgayNhan=@ngayNhan, NoiDungTB=@noiDungTB, TrangThaiTB=@trangThaiTB  where MaTb=@idTB", con);
            cmd.Parameters.AddWithValue("@idTB", ttThongBao.maThongBao);
            cmd.Parameters.AddWithValue("@nguoiGui", ttThongBao.nguoiGui);
            cmd.Parameters.AddWithValue("@nguoiNhan", ttThongBao.nguoiNhan);
            cmd.Parameters.AddWithValue("@ngayGui", ttThongBao.ngayGui);
            cmd.Parameters.AddWithValue("@ngayNhan", ttThongBao.ngayNhan);
            cmd.Parameters.AddWithValue("@noiDungTB", ttThongBao.noiDungTB);
            cmd.Parameters.AddWithValue("@trangThaiTB", ttThongBao.trangThaiThongBao);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // 11. bang hoa don
        public string InsertHD(HoaDon ttHD)
        {
            string Message;
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Hoadon(MaHD,MaPH,ThanhTien,TongTien,TrangThai,NgayLap,ThangLap,NamLap) values(@idHD,@maPH,@thanhTien,@tongTien,@trangThai,@ngayLap,@thangLap,@namlap)", con);
            cmd.Parameters.AddWithValue("@idHD", ttHD.maHD);
            cmd.Parameters.AddWithValue("@maPH", ttHD.maPH);
            cmd.Parameters.AddWithValue("@thanhTien", ttHD.thanhTien);
            cmd.Parameters.AddWithValue("@tongTien", ttHD.tongTien);
            cmd.Parameters.AddWithValue("@trangThai", ttHD.trangThai);
            cmd.Parameters.AddWithValue("@ngayLap", ttHD.ngayLap);
            cmd.Parameters.AddWithValue("@thangLap", ttHD.thangLap);
            cmd.Parameters.AddWithValue("@namLap", ttHD.namLap);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = "hoa dong duoc them thanh cong";
            }
            else
            {
                Message = "hoa don them khong thanh cong";
            }
            con.Close();
            return Message;
        }

        public DataSet SelectHD()
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from HoaDon", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }

        public bool DeleteHD(HoaDon ttHD)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from HoaDon where MaHD=@idHD", con);
            cmd.Parameters.AddWithValue("@idHD", ttHD.maHD);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public void UpdateHD(HoaDon ttHD)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("update HoaDon set MaPH=@maPH, ThanhTien=@thanhTien, TongTien=@tongTien, TrangThai=@trangThai, NgayLap=@ngayLap, ThangLap=@thangLap, NamLap=@namLap  where MaHD=@idHD", con);
            cmd.Parameters.AddWithValue("@idHD", ttHD.maHD);
            cmd.Parameters.AddWithValue("@maPH", ttHD.maPH);
            cmd.Parameters.AddWithValue("@thanhTien", ttHD.thanhTien);
            cmd.Parameters.AddWithValue("@tongTien", ttHD.tongTien);
            cmd.Parameters.AddWithValue("@trangThai", ttHD.trangThai);
            cmd.Parameters.AddWithValue("@ngayLap", ttHD.ngayLap);
            cmd.Parameters.AddWithValue("@thangLap", ttHD.thangLap);
            cmd.Parameters.AddWithValue("@namLap", ttHD.namLap);
            cmd.ExecuteNonQuery();
            con.Close();
        }

      

        // 13. bang phieu dat phong
        public string InsertPhieuDatPhong(PhieuDatPhong ttPhieuDatPhong)
        {
            string Message;
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Hoadon(SoPD,NgayDat,GioDat,MaPH,MaKH) values(@idSoPD,@ngayDat,@gioDat,@maPH,@maKH)", con);
            cmd.Parameters.AddWithValue("@idSoPD", ttPhieuDatPhong.soPD);
            cmd.Parameters.AddWithValue("@ngayDat", ttPhieuDatPhong.ngayDat);
            cmd.Parameters.AddWithValue("@gioDat", ttPhieuDatPhong.gioDat);
            cmd.Parameters.AddWithValue("@maPH", ttPhieuDatPhong.maPH);
            cmd.Parameters.AddWithValue("@maKH", ttPhieuDatPhong.maKH);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = "phieu dat phong hat duoc them thanh cong";
            }
            else
            {
                Message = "phieu dat phong hat them khong thanh cong";
            }
            con.Close();
            return Message;
        }

        public DataSet SelectPhieuDatPhong()
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from PhieuDatPhong", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }

        public bool DeletePhieuDatPhong(PhieuDatPhong ttPhieuDatPhong)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from PhieuDatPHong where SoPD=@idSoPD", con);
            cmd.Parameters.AddWithValue("@idSoPD", ttPhieuDatPhong.soPD);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public void UpdatePhieuDatPhong(PhieuDatPhong ttPhieuDatPhong)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("update PhieuDatPhong set NgayDat=@ngayDat, GioDat=@gioDat, MaPH=@maPH, MaKH=@maKH  where SoPD=@idSoPD", con);
            cmd.Parameters.AddWithValue("@idSoPD", ttPhieuDatPhong.soPD);
            cmd.Parameters.AddWithValue("@ngayDat", ttPhieuDatPhong.ngayDat);
            cmd.Parameters.AddWithValue("@gioDat", ttPhieuDatPhong.gioDat);
            cmd.Parameters.AddWithValue("@maPH", ttPhieuDatPhong.maPH);
            cmd.Parameters.AddWithValue("@maKH", ttPhieuDatPhong.maKH);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // 14. bang nhan phong
        public string InsertNhanPhong(NhanPhong ttNhanPhong)
        {
            string Message;
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into NhanPhong(MaNP,TenKH,NgayNhan,GioNhan,MaPH,SoLuongNguoi,SoDienThoai) values(@maNP,@tenKH,@ngayNhan,@gioNhan,@maPH,@soLuongNguoi,@soDienThoai)", con);
            cmd.Parameters.AddWithValue("@maNP", ttNhanPhong.maNP);
            cmd.Parameters.AddWithValue("@tenKH", ttNhanPhong.tenKH);
            cmd.Parameters.AddWithValue("@ngayNhan", ttNhanPhong.ngayNhan);
            cmd.Parameters.AddWithValue("@gioNhan", ttNhanPhong.gioNhan);
            cmd.Parameters.AddWithValue("@maPH", ttNhanPhong.maPH);
            cmd.Parameters.AddWithValue("@soLuongNguoi", ttNhanPhong.soLuongNguoi);
            cmd.Parameters.AddWithValue("@soDienThoai", ttNhanPhong.soDienThoai);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = "nhan phong thanh cong";
            }
            else
            {
                Message = "nhan phong khong thanh cong";
            }
            con.Close();
            return Message;
        }

        public DataSet SelectNhanPhong()
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from NhanPhong", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }

        public bool DeleteNhanPhong(NhanPhong ttNhanPhong)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from NhanPhong where MaNP=@idNP", con);
            cmd.Parameters.AddWithValue("@idNP", ttNhanPhong.maNP);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public void UpdateNhanPhong(NhanPhong ttNhanPhong)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("update NhanPhong set TenKH=@tenKH, NgayNhan=@ngayNhan, GioNhan=@gioNhan, MaPH=@maPH, SoLuongNguoi=@soLuongNguoi, SoDienThoai=@soDienThoai  where MaNP=@maNP", con);
            cmd.Parameters.AddWithValue("@maNP", ttNhanPhong.maNP);
            cmd.Parameters.AddWithValue("@tenKH", ttNhanPhong.tenKH);
            cmd.Parameters.AddWithValue("@ngayNhan", ttNhanPhong.ngayNhan);
            cmd.Parameters.AddWithValue("@gioNhan", ttNhanPhong.gioNhan);
            cmd.Parameters.AddWithValue("@maPH", ttNhanPhong.maPH);
            cmd.Parameters.AddWithValue("@soLuongNguoi",ttNhanPhong.soLuongNguoi);
            cmd.Parameters.AddWithValue("@soDienThoai", ttNhanPhong.soDienThoai);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataSet timKiemTB(ThietBi tkTB)
        {
            SqlConnection con = new SqlConnection(strQuery);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from ThietBi where TenTB=@TenTB", con);
            cmd.Parameters.AddWithValue("@TenTB", tkTB.tenTB);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            cmd.ExecuteNonQuery();
            sda.Fill(ds);
            con.Close();
            return ds;
        
        }
    }
}
