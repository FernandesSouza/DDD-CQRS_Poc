using DomainDrivenDesign_Poc.Business.Domain.Entities;
using DomainDrivenDesign_Poc.Business.Domain.Entities.Base;
using DomainDrivenDesign_Poc.Business.Domain.Enums;

namespace DomainDrivenDesign_Poc.Business.Domain.Entities;

public sealed class Subscription : Entity
{
    //ORM
    protected Subscription()
    {
    }

    public Subscription(
        DateTime? expireDate,
        ETypeSubscription typeSubscription,
        DateTime createDate)
    {
        ExpireDate = expireDate;
        TypeSubscription = typeSubscription;
        CreateDate = createDate;
    }

    public void LinkedToStudent(Guid studentId)
    {
        StudentId = studentId;
    }

    public void AddPayments(Payment payment)
    {
        _payments.Add(payment);
    }

    public void Active()
    {
        IsActive = true;
        LastUpdateDate = DateTime.Now;
    }

    public void Inactive()
    {
        IsActive = false;
        LastUpdateDate = DateTime.Now;
    }

    private readonly List<Payment> _payments = [];

    public DateTime CreateDate { get; init; } = DateTime.Now;
    public DateTime? LastUpdateDate { get; set; } = DateTime.Now;
    public DateTime? ExpireDate { get; set; }
    public Student? Student { get; set; }
    public Guid StudentId { get; set; }
    public bool IsActive { get; set; } = true;

    public ETypeSubscription TypeSubscription { get; set; }
    public IReadOnlyCollection<Payment> Payments => _payments.ToArray();
}