using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Domain.Entities
{
    public class Media : BaseEntities
    {
        public string FileName { get; set; }              // Tên file gốc
        public string FilePath { get; set; }              // Đường dẫn lưu trữ (relative hoặc absolute)
        public string FileType { get; set; }              // MIME type: "image/png", "video/mp4", ...
        public long FileSize { get; set; }                // Kích thước (bytes)
        public string Description { get; set; }           // Mô tả nếu cần
    }
}
