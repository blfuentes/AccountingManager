using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AccountManager.DAL.EF.Models
{
    public partial class AccountManagerContext : DbContext
    {
        public AccountManagerContext()
        {
        }

        public AccountManagerContext(DbContextOptions<AccountManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<ActivityType> ActivityType { get; set; }
        public virtual DbSet<Balance> Balance { get; set; }
        public virtual DbSet<Expense> Expense { get; set; }
        public virtual DbSet<ExpenseFamily> ExpenseFamily { get; set; }
        public virtual DbSet<ExpenseModification> ExpenseModification { get; set; }
        public virtual DbSet<ExpenseType> ExpenseType { get; set; }
        public virtual DbSet<ForecastDetail> ForecastDetail { get; set; }
        public virtual DbSet<ForecastDetailExpense> ForecastDetailExpense { get; set; }
        public virtual DbSet<Motive> Motive { get; set; }
        public virtual DbSet<Movement> Movement { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Present> Present { get; set; }
        public virtual DbSet<Salary> Salary { get; set; }
        public virtual DbSet<SalaryModification> SalaryModification { get; set; }
        public virtual DbSet<SalaryModificationType> SalaryModificationType { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Target> Target { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<TransactionType> TransactionType { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(_connectionString);
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.ActivityTypeId).HasColumnName("ActivityTypeID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.ActivityType)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.ActivityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_ToActivityType");
            });

            modelBuilder.Entity<ActivityType>(entity =>
            {
                entity.Property(e => e.ActivityTypeId).HasColumnName("ActivityTypeID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Balance>(entity =>
            {
                entity.Property(e => e.BalanceId).HasColumnName("BalanceID");

                entity.Property(e => e.FinalAmount).HasColumnType("money");

                entity.Property(e => e.InitialAmount).HasColumnType("money");

                entity.Property(e => e.Variation)
                    .HasColumnType("money")
                    .HasComputedColumnSql("([FinalAmount]-[InitialAmount])");
            });

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.Property(e => e.ExpenseId).HasColumnName("ExpenseID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.ExpenseTypeId).HasColumnName("ExpenseTypeID");

                entity.HasOne(d => d.ExpenseType)
                    .WithMany(p => p.Expense)
                    .HasForeignKey(d => d.ExpenseTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Expense_ToExpenseType");
            });

            modelBuilder.Entity<ExpenseFamily>(entity =>
            {
                entity.Property(e => e.ExpenseFamilyId).HasColumnName("ExpenseFamilyID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ExpenseModification>(entity =>
            {
                entity.Property(e => e.ExpenseModificationId).HasColumnName("ExpenseModificationID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.ExpenseId).HasColumnName("ExpenseID");

                entity.HasOne(d => d.Expense)
                    .WithMany(p => p.ExpenseModification)
                    .HasForeignKey(d => d.ExpenseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExpenseModification_ToExpense");
            });

            modelBuilder.Entity<ExpenseType>(entity =>
            {
                entity.Property(e => e.ExpenseTypeId).HasColumnName("ExpenseTypeID");

                entity.Property(e => e.ExpenseFamilyId).HasColumnName("ExpenseFamilyID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.ExpenseFamily)
                    .WithMany(p => p.ExpenseType)
                    .HasForeignKey(d => d.ExpenseFamilyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExpenseType_ToExpenseFamily");
            });

            modelBuilder.Entity<ForecastDetail>(entity =>
            {
                entity.Property(e => e.ForecastDetailId).HasColumnName("ForecastDetailID");

                entity.Property(e => e.Adjustment).HasColumnType("money");

                entity.Property(e => e.BalanceEstimation).HasColumnType("money");

                entity.Property(e => e.CarAmount).HasColumnType("money");

                entity.Property(e => e.Comments).HasMaxLength(255);

                entity.Property(e => e.CreditAmount).HasColumnType("money");

                entity.Property(e => e.Estimation).HasColumnType("money");

                entity.Property(e => e.ExtraExpenses).HasColumnType("money");

                entity.Property(e => e.FinalAmount).HasColumnType("money");

                entity.Property(e => e.FinalBalance).HasColumnType("money");

                entity.Property(e => e.FlightAmount).HasColumnType("money");

                entity.Property(e => e.InitialBalance).HasColumnType("money");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.ForecastDetail)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ForecastDetail_ToPayment");
            });

            modelBuilder.Entity<ForecastDetailExpense>(entity =>
            {
                entity.HasKey(e => new { e.ExpenseId, e.ForecastDetailId })
                    .HasName("PK__Forecast__C6644A4BCD2A2579");

                entity.ToTable("ForecastDetail_Expense");

                entity.Property(e => e.ExpenseId).HasColumnName("ExpenseID");

                entity.Property(e => e.ForecastDetailId).HasColumnName("ForecastDetailID");

                entity.HasOne(d => d.Expense)
                    .WithMany(p => p.ForecastDetailExpense)
                    .HasForeignKey(d => d.ExpenseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ForecastDetail_Expense_ToExpense");

                entity.HasOne(d => d.ForecastDetail)
                    .WithMany(p => p.ForecastDetailExpense)
                    .HasForeignKey(d => d.ForecastDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ForecastDetail_Expense_ToForecastDetail");
            });

            modelBuilder.Entity<Motive>(entity =>
            {
                entity.Property(e => e.MotiveId).HasColumnName("MotiveID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Movement>(entity =>
            {
                entity.Property(e => e.MovementId).HasColumnName("MovementID");

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.Movement)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movement_ToActivity");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.Amount).HasColumnType("money");
            });

            modelBuilder.Entity<Present>(entity =>
            {
                entity.Property(e => e.PresentId).HasColumnName("PresentID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.MotiveId).HasColumnName("MotiveID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.TargetId).HasColumnName("TargetID");

                entity.HasOne(d => d.Motive)
                    .WithMany(p => p.Present)
                    .HasForeignKey(d => d.MotiveId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Present_ToMotive");

                entity.HasOne(d => d.Target)
                    .WithMany(p => p.Present)
                    .HasForeignKey(d => d.TargetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Present_ToTarget");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.Property(e => e.SalaryId).HasColumnName("SalaryID");

                entity.Property(e => e.BasePayment).HasColumnType("money");

                entity.Property(e => e.NetPayment).HasColumnType("money");
            });

            modelBuilder.Entity<SalaryModification>(entity =>
            {
                entity.Property(e => e.SalaryModificationId).HasColumnName("SalaryModificationID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.SalaryId).HasColumnName("SalaryID");

                entity.Property(e => e.SalaryModificationTypeId).HasColumnName("SalaryModificationTypeID");

                entity.HasOne(d => d.Salary)
                    .WithMany(p => p.SalaryModification)
                    .HasForeignKey(d => d.SalaryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SalaryModification_ToSalary");

                entity.HasOne(d => d.SalaryModificationType)
                    .WithMany(p => p.SalaryModification)
                    .HasForeignKey(d => d.SalaryModificationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SalaryModification_ToSalaryModificationType");
            });

            modelBuilder.Entity<SalaryModificationType>(entity =>
            {
                entity.Property(e => e.SalaryModificationTypeId).HasColumnName("SalaryModificationTypeID");

                entity.Property(e => e.DefaultValue).HasColumnType("money");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Status)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Status_ToAccount");
            });

            modelBuilder.Entity<Target>(entity =>
            {
                entity.Property(e => e.TargetId).HasColumnName("TargetID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.MovementId).HasColumnName("MovementID");

                entity.Property(e => e.OriginAccountId).HasColumnName("OriginAccountID");

                entity.Property(e => e.TargetAccountId).HasColumnName("TargetAccountID");

                entity.Property(e => e.TransactionTypeId).HasColumnName("TransactionTypeID");

                entity.HasOne(d => d.Movement)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.MovementId)
                    .HasConstraintName("FK_Transaction_ToMovement");

                entity.HasOne(d => d.OriginAccount)
                    .WithMany(p => p.TransactionOriginAccount)
                    .HasForeignKey(d => d.OriginAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction_ToAccountOrigin");

                entity.HasOne(d => d.TargetAccount)
                    .WithMany(p => p.TransactionTargetAccount)
                    .HasForeignKey(d => d.TargetAccountId)
                    .HasConstraintName("FK_Transaction_ToAccountTarget");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction_ToTransactionType");
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.Property(e => e.TransactionTypeId).HasColumnName("TransactionTypeID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
