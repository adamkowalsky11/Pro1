using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pizzeria.Models
{
    public partial class s16788Context : DbContext
    {
        public s16788Context()
        {
        }

        public s16788Context(DbContextOptions<s16788Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<Emp> Emp { get; set; }
        public virtual DbSet<GotowaPizza> GotowaPizza { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<Rodzaj> Rodzaj { get; set; }
        public virtual DbSet<Rozmiar> Rozmiar { get; set; }
        public virtual DbSet<Skladnik> Skladnik { get; set; }
        public virtual DbSet<Sos> Sos { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }

        // Unable to generate entity type for table 'dbo.DEPT'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.SALGRADE'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s16788;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasKey(e => e.IdAdministrator)
                    .HasName("Administrator_pk");

                entity.Property(e => e.IdAdministrator)
                    .HasColumnName("idAdministrator")
                    .ValueGeneratedNever();

                entity.Property(e => e.Imie).HasColumnName("imie");

                entity.Property(e => e.Login).HasColumnName("login");

                entity.Property(e => e.Nazwisko).HasColumnName("nazwisko");
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.HasKey(e => e.Empno)
                    .HasName("PK__EMP__14CCF2EE12442AC4");

                entity.ToTable("EMP");

                entity.Property(e => e.Empno)
                    .HasColumnName("EMPNO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comm).HasColumnName("COMM");

                entity.Property(e => e.Deptno).HasColumnName("DEPTNO");

                entity.Property(e => e.Ename)
                    .HasColumnName("ENAME")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hiredate)
                    .HasColumnName("HIREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Job)
                    .HasColumnName("JOB")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Mgr).HasColumnName("MGR");

                entity.Property(e => e.Sal).HasColumnName("SAL");
            });

            modelBuilder.Entity<GotowaPizza>(entity =>
            {
                entity.HasKey(e => e.IdGotowaPizza)
                    .HasName("GotowaPizza_pk");

                entity.Property(e => e.IdGotowaPizza)
                    .HasColumnName("idGotowaPizza")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cena).HasColumnName("cena");

                entity.Property(e => e.PizzaIdPizza).HasColumnName("Pizza_idPizza");

                entity.Property(e => e.RodzajIdRodzaj).HasColumnName("Rodzaj_idRodzaj");

                entity.Property(e => e.RozmiarIdRozmiar).HasColumnName("Rozmiar_idRozmiar");

                entity.Property(e => e.SkladnikIdSkladnik).HasColumnName("Skladnik_idSkladnik");

                entity.HasOne(d => d.PizzaIdPizzaNavigation)
                    .WithMany(p => p.GotowaPizza)
                    .HasForeignKey(d => d.PizzaIdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ListaSkladnikow_Pizza");

                entity.HasOne(d => d.RodzajIdRodzajNavigation)
                    .WithMany(p => p.GotowaPizza)
                    .HasForeignKey(d => d.RodzajIdRodzaj)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GotowaPizza_Rodzaj");

                entity.HasOne(d => d.RozmiarIdRozmiarNavigation)
                    .WithMany(p => p.GotowaPizza)
                    .HasForeignKey(d => d.RozmiarIdRozmiar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GotowaPizza_Rozmiar");

                entity.HasOne(d => d.SkladnikIdSkladnikNavigation)
                    .WithMany(p => p.GotowaPizza)
                    .HasForeignKey(d => d.SkladnikIdSkladnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ListaSkladnikow_Skladnik");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdPizza)
                    .HasName("Pizza_pk");

                entity.Property(e => e.IdPizza)
                    .HasColumnName("idPizza")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SosIdSos).HasColumnName("Sos_idSos");

                entity.HasOne(d => d.SosIdSosNavigation)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.SosIdSos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Sos");
            });

            modelBuilder.Entity<Rodzaj>(entity =>
            {
                entity.HasKey(e => e.IdRodzaj)
                    .HasName("Rodzaj_pk");

                entity.Property(e => e.IdRodzaj)
                    .HasColumnName("idRodzaj")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cena)
                    .IsRequired()
                    .HasColumnName("cena")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Rodzaj1)
                    .IsRequired()
                    .HasColumnName("rodzaj")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rozmiar>(entity =>
            {
                entity.HasKey(e => e.IdRozmiar)
                    .HasName("Rozmiar_pk");

                entity.Property(e => e.IdRozmiar)
                    .HasColumnName("idRozmiar")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cena)
                    .IsRequired()
                    .HasColumnName("cena")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Rozmiar1)
                    .IsRequired()
                    .HasColumnName("rozmiar")
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Skladnik>(entity =>
            {
                entity.HasKey(e => e.IdSkladnik)
                    .HasName("Skladnik_pk");

                entity.Property(e => e.IdSkladnik)
                    .HasColumnName("idSkladnik")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sos>(entity =>
            {
                entity.HasKey(e => e.IdSos)
                    .HasName("Sos_pk");

                entity.Property(e => e.IdSos)
                    .HasColumnName("idSos")
                    .ValueGeneratedNever();

                entity.Property(e => e.Sos1)
                    .IsRequired()
                    .HasColumnName("sos")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienie)
                    .HasName("Zamowienie_pk");

                entity.Property(e => e.IdZamowienie)
                    .HasColumnName("idZamowienie")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdministratorIdAdministrator).HasColumnName("Administrator_idAdministrator");

                entity.Property(e => e.EmailKlienta)
                    .IsRequired()
                    .HasColumnName("emailKlienta")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GotowaPizzaIdGotowaPizza).HasColumnName("GotowaPizza_idGotowaPizza");

                entity.Property(e => e.ImieKlienta).HasColumnName("imieKlienta");

                entity.Property(e => e.KodPocztowyKlienta)
                    .IsRequired()
                    .HasColumnName("kodPocztowyKlienta")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.KosztCalkowity)
                    .IsRequired()
                    .HasColumnName("kosztCalkowity")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.NazwiskoKlienta).HasColumnName("nazwiskoKlienta");

                entity.Property(e => e.NrBudynkuKlienta).HasColumnName("nrBudynkuKlienta");

                entity.Property(e => e.NrMieszkaniaKlienta).HasColumnName("nrMieszkaniaKlienta");

                entity.Property(e => e.NrTelefonuKlienta)
                    .IsRequired()
                    .HasColumnName("nrTelefonuKlienta")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.SzacowanaDataDostarczenia).HasColumnName("szacowanaDataDostarczenia");

                entity.Property(e => e.UlicaKlienta)
                    .IsRequired()
                    .HasColumnName("ulicaKlienta")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AdministratorIdAdministratorNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.AdministratorIdAdministrator)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Administrator");

                entity.HasOne(d => d.GotowaPizzaIdGotowaPizzaNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.GotowaPizzaIdGotowaPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_GotowaPizza");
            });
        }
    }
}
