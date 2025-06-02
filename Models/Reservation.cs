using System;
using System.ComponentModel.DataAnnotations;
using lab6_op.Models;

public class Reservation : BaseEntity, IReservation
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public int BookId { get; set; }

    [Required(ErrorMessage = "Початкова дата є обов’язковою")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "Кінцева дата є обов’язковою")]
    public DateTime EndDate { get; set; }

    public virtual bool IsReserved { get; set; } = false;

    public Reservation(int id, int userId, int bookId) : base(id)
    {
        UserId = userId;
        BookId = bookId;
        StartDate = DateTime.MinValue;
        EndDate = DateTime.MinValue;
        IsReserved = false;
    }

    public virtual void Reserve(DateTime startDate, DateTime endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
        IsReserved = true;
    }

    public virtual void CancelReservation()
    {
        IsReserved = false;
        StartDate = DateTime.MinValue;
        EndDate = DateTime.MinValue;
    }
}
