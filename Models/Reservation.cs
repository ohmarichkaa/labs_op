using lab6_op.Models;

public class Reservation : BaseEntity, IReservation
{
    public int UserId { get; set; }
    public int BookId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public virtual bool IsReserved { get; set; } = false;

    public Reservation(int id, int userId, int bookId) : base(id)
    {
        UserId = userId;
        BookId = bookId;
        IsReserved = false;
        StartDate = DateTime.MinValue;
        EndDate = DateTime.MinValue;
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
