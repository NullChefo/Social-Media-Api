namespace SMA.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseEntity
    {
        #region Constructors
        public BaseEntity()
        {
            CreatedOn = DateTime.Now;
        }
        #endregion

        #region Properties

        [Key]
        public int Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int UpdatedByUserId { get; set; }

        public DateTime? UpdatedOn { get; set; }

        #endregion
    }
}
