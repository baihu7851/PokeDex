using System.ComponentModel.DataAnnotations;

namespace PokeDex.Models
{
    /// <summary>
    /// 使用者基本資料
    /// </summary>
    public class User
    {
        /// <summary>
        /// 流水編號
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 帳號
        /// 長度6~12
        /// </summary>
        [Required]
        [StringLength(12, MinimumLength = 6)]
        public string Account { get; set; } = "Trainer";

        /// <summary>
        /// 帳號
        /// 長度6~12
        /// </summary>

        [EmailAddress]
        [StringLength(12, MinimumLength = 6)]
        public string? Email { get; set; }

        /// <summary>
        /// 密碼
        /// 長度6~18，必須用英數字組合
        /// </summary>
        [Required]
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*\d)[a-zA-Z\d]{6,18}$")]
        public string Password { get; set; } = "PassW0rd";

        /// <summary>
        /// 名稱
        /// 長度2~8
        /// </summary>
        [Required]
        [StringLength(8, MinimumLength = 2)]
        public string Name { get; set; } = "寶可夢訓練家";

        /// <summary>
        /// 照片
        /// </summary>
        [StringLength(500)]
        public string? Photo { get; set; }

        /// <summary>
        /// 創建時間
        /// </summary>
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// 更新時間
        /// </summary>
        public DateTime? UpdatedTime { get; set; }
    }
}