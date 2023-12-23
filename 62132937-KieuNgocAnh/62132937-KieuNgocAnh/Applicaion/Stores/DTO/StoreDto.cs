using _62132937_KieuNgocAnh.Models.Entity;

namespace _62132937_KieuNgocAnh.Applicaion.Stores.DTO
{
    public class StoreDto
    {
        public string Name { get;  set; }
        public string Address { get;  set; }
    }


    public class StoreDetail
    {
        public int Id { get; set; } 
        public string Name { get;  set; }
        public string Address { get;  set; }
        public bool IsDeleted { get;  set; } = false;
    }
}
