using System.ComponentModel.DataAnnotations;

namespace CRIP.Models
{
    public class BaseEntity
    {
        private string _state = "正常";
        [Key]
        public string Id { get; set; }//主键
        [Required]
        public string State {
            get
            {
               return _state;
            }
            set { 
                _state = value;
            }
        }//实体状态


    }
}
