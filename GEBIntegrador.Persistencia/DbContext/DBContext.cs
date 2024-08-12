using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GEBIntegrador.Dominio;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    //public virtual DbSet<agenda> agenda { get; set; }

    //public virtual DbSet<area> areas { get; set; }

    //public virtual DbSet<arl> arls { get; set; }

    public virtual DbSet<categorias_parqueadero> categorias_parqueaderos { get; set; }

    //public virtual DbSet<contrato> contratos { get; set; }

    //public virtual DbSet<contrato_autorizadore> contrato_autorizadores { get; set; }

    //public virtual DbSet<contrato_regional> contrato_regionals { get; set; }

    //public virtual DbSet<dias_restringido> dias_restringidos { get; set; }

    //public virtual DbSet<eps> eps { get; set; }

    //public virtual DbSet<jornada> jornada { get; set; }

    public virtual DbSet<menu> menus { get; set; }

    public virtual DbSet<menu_perfil> menu_perfils { get; set; }

    public virtual DbSet<niveles> niveles { get; set; }

    public virtual DbSet<parametro> parametros { get; set; }

    public virtual DbSet<perfile> perfiles { get; set; }

    public virtual DbSet<permiso> permisos { get; set; }

    public virtual DbSet<permisos_perfil> permisos_perfils { get; set; }

    public virtual DbSet<persona> personas { get; set; }

    public virtual DbSet<recurso> recursos { get; set; }

   // public virtual DbSet<regional> regionals { get; set; }

    public virtual DbSet<reserva> reservas { get; set; }

    //public virtual DbSet<sede> sedes { get; set; }

    //public virtual DbSet<sede_area> sede_areas { get; set; }

    //public virtual DbSet<solicitud_actividades> solicitud_actividades { get; set; }

    //public virtual DbSet<solicitud_area> solicitud_areas { get; set; }

    //public virtual DbSet<solicitud_asistente> solicitud_asistentes { get; set; }

    //public virtual DbSet<solicitud_cabecera> solicitud_cabeceras { get; set; }

    //public virtual DbSet<solicitud_medidas_seguridad> solicitud_medidas_seguridads { get; set; }

    //public virtual DbSet<solicitud_rol> solicitud_rols { get; set; }

    //public virtual DbSet<solicitud_vehiculo> solicitud_vehiculos { get; set; }

    public virtual DbSet<tipos_recurso> tipos_recursos { get; set; }

    public virtual DbSet<tipos_reserva> tipos_reservas { get; set; }

    public virtual DbSet<usuario> usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
   protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<agenda>(entity =>
        //{
        //    entity.HasKey(e => e.n_id).HasName("PK__agenda__7371E14E884BE226");

        //    entity.Property(e => e.n_estado).HasDefaultValueSql("((1))");

        //    entity.HasOne(d => d.n_id_recursoNavigation).WithMany(p => p.agenda)
        //        .HasForeignKey(d => d.n_id_recurso)
        //        .HasConstraintName("FK__agenda__n_id_rec__55009F39");
        //});

        //modelBuilder.Entity<area>(entity =>
        //{
        //    entity.HasKey(e => e.n_id).HasName("PK__area__7371E14E0A3E1ED7");

        //    entity.ToTable("area");

        //    entity.Property(e => e.n_estado).HasDefaultValueSql("((1))");
        //    entity.Property(e => e.v_descripcion).IsUnicode(false);
        //});

        //modelBuilder.Entity<arl>(entity =>
        //{
        //    entity.HasKey(e => e.n_id).HasName("PK__arl__7371E14E23C8E43A");

        //    entity.ToTable("arl");

        //    entity.Property(e => e.v_descripcion)
        //        .HasMaxLength(100)
        //        .IsUnicode(false);
        //});

        modelBuilder.Entity<categorias_parqueadero>(entity =>
        {
            entity.HasKey(e => e.n_id).HasName("PK__tipos_mo__7371E14E3A5CC62D");

            entity.ToTable("categorias_parqueadero");

            entity.Property(e => e.n_estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.v_descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        //modelBuilder.Entity<contrato>(entity =>
        //{
        //    entity.HasKey(e => e.n_id).HasName("PK__contrati__7371E14E478AF767");

        //    entity.ToTable("contrato");

        //    entity.Property(e => e.d_fecha_actualiza).HasColumnType("datetime");
        //    entity.Property(e => e.d_fecha_crea)
        //        .HasDefaultValueSql("(getdate())")
        //        .HasColumnType("datetime");
        //    entity.Property(e => e.n_estado).HasDefaultValueSql("((1))");
        //    entity.Property(e => e.n_id_usuario_crea).HasDefaultValueSql("((1))");
        //    entity.Property(e => e.v_empresa_contratista)
        //        .HasMaxLength(100)
        //        .IsUnicode(false);
        //    entity.Property(e => e.v_empresa_ejecuta)
        //        .HasMaxLength(100)
        //        .IsUnicode(false);
        //    entity.Property(e => e.v_num_contrato)
        //        .HasMaxLength(100)
        //        .IsUnicode(false);

        //    entity.HasOne(d => d.n_id_usuario_actualizaNavigation).WithMany(p => p.contraton_id_usuario_actualizaNavigations)
        //        .HasForeignKey(d => d.n_id_usuario_actualiza)
        //        .HasConstraintName("FK__contrato__n_id_u__220B0B18");

        //    entity.HasOne(d => d.n_id_usuario_creaNavigation).WithMany(p => p.contraton_id_usuario_creaNavigations)
        //        .HasForeignKey(d => d.n_id_usuario_crea)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK__contrato__n_id_u__2116E6DF");
        //});

        //modelBuilder.Entity<contrato_autorizadore>(entity =>
        //{
        //    entity.HasKey(e => e.n_id).HasName("PK__contrato__7371E14EDB20DC9B");

        //    entity.Property(e => e.n_estado).HasDefaultValueSql("((1))");
        //    entity.Property(e => e.n_nivel_autorizacion).HasDefaultValueSql("((1))");

        //    entity.HasOne(d => d.n_id_contratoNavigation).WithMany(p => p.contrato_autorizadores)
        //        .HasForeignKey(d => d.n_id_contrato)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK__contrato___n_id___7C1A6C5A");

        //    entity.HasOne(d => d.n_id_usuarioNavigation).WithMany(p => p.contrato_autorizadores)
        //        .HasForeignKey(d => d.n_id_usuario)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK__contrato___n_id___7D0E9093");
        //});

        //modelBuilder.Entity<contrato_regional>(entity =>
        //{
        //    entity.HasKey(e => e.n_id).HasName("PK__contrato__7371E14E64ED09FF");

        //    entity.ToTable("contrato_regional");

        //    entity.Property(e => e.n_estado)
        //        .HasDefaultValueSql("((0))")
        //        .HasComment("1- Significa activo 0- Inactivo");

        //    entity.HasOne(d => d.n_id_contratoNavigation).WithMany(p => p.contrato_regionals)
        //        .HasForeignKey(d => d.n_id_contrato)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK__contrato___n_id___7755B73D");

        //    entity.HasOne(d => d.n_id_regionalNavigation).WithMany(p => p.contrato_regionals)
        //        .HasForeignKey(d => d.n_id_regional)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK__contrato___n_id___7849DB76");
        //});

        //modelBuilder.Entity<dias_restringido>(entity =>
        //{
        //    entity.HasKey(e => e.n_id).HasName("PK__dias_res__7371E14E83B2FB61");

        //    entity.Property(e => e.d_fecha).HasColumnType("date");
        //    entity.Property(e => e.n_estado).HasDefaultValueSql("((1))");
        //    entity.Property(e => e.v_observacion).IsUnicode(false);
        //});

        //modelBuilder.Entity<eps>(entity =>
        //{
        //    entity.HasKey(e => e.n_id).HasName("PK__eps__7371E14E27DB09FA");

        //    entity.Property(e => e.v_descripcion)
        //        .HasMaxLength(100)
        //        .IsUnicode(false);
        //});

        //modelBuilder.Entity<jornada>(entity =>
        //{
        //    entity.HasKey(e => e.n_id).HasName("PK__jornada__7371E14E5BECB039");

        //    entity.Property(e => e.n_estado).HasDefaultValueSql("((1))");
        //    entity.Property(e => e.v_descripcion)
        //        .HasMaxLength(255)
        //        .IsUnicode(false);
        //});

        modelBuilder.Entity<menu>(entity =>
        {
            entity.HasKey(e => e.n_id_menu).HasName("PK__Menu__68A1D9DBC8DACE31");

            entity.ToTable("menu");

            entity.HasIndex(e => e.n_id_menu_padre, "IX_Menu_id_menu_padre");

            entity.Property(e => e.n_estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.v_descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.v_url)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.n_id_menu_padreNavigation).WithMany(p => p.Inversen_id_menu_padreNavigation)
                .HasForeignKey(d => d.n_id_menu_padre)
                .HasConstraintName("FK__Menu__id_menu_pa__48CFD27E");
        });

        modelBuilder.Entity<menu_perfil>(entity =>
        {
            entity.HasKey(e => e.n_id).HasName("PK__menu_per__3213E83F7A911AF2");

            entity.ToTable("menu_perfil");

            entity.HasIndex(e => e.n_id_menu, "IX_menu_perfil_id_menu");

            entity.HasIndex(e => e.n_id_perfil, "IX_menu_perfil_id_perfil");

            entity.Property(e => e.n_estado).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.n_id_menuNavigation).WithMany(p => p.menu_perfils)
                .HasForeignKey(d => d.n_id_menu)
                .HasConstraintName("FK__menu_perf__id_me__5441852A");

            entity.HasOne(d => d.n_id_perfilNavigation).WithMany(p => p.menu_perfils)
                .HasForeignKey(d => d.n_id_perfil)
                .HasConstraintName("FK__menu_perf__id_pe__5535A963");
        });

        modelBuilder.Entity<niveles>(entity =>
        {
            entity.HasKey(e => e.n_id).HasName("PK__niveles__7371E14E127273B8");

            entity.Property(e => e.n_estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.v_descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<parametro>(entity =>
        {
            entity.HasKey(e => e.n_id).HasName("PK__parametr__3213E83F70AE321F");

            entity.Property(e => e.d_fecha_actualiza)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.n_estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.v_descripcion_parametro).IsUnicode(false);
            entity.Property(e => e.v_valor)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<perfile>(entity =>
        {
            entity.HasKey(e => e.n_id);

            entity.Property(e => e.n_estado)
                .HasDefaultValueSql("((1))")
                .HasComment("0-InActivo 1-Activo");
            entity.Property(e => e.v_descripcion).IsUnicode(false);
            entity.Property(e => e.v_nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<permiso>(entity =>
        {
            entity.HasKey(e => e.n_id).HasName("PK__permisos__3213E83FD9756A20");

            entity.Property(e => e.n_estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.v_descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.v_nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<permisos_perfil>(entity =>
        {
            entity.HasKey(e => e.n_id).HasName("PK__permisos__3213E83FF964A87E");

            entity.ToTable("permisos_perfil");

            entity.HasIndex(e => e.n_id_perfil, "IX_permisos_perfil_id_perfil");

            entity.HasIndex(e => e.n_id_permiso, "IX_permisos_perfil_id_permiso");

            entity.Property(e => e.n_estado).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.n_id_perfilNavigation).WithMany(p => p.permisos_perfils)
                .HasForeignKey(d => d.n_id_perfil)
                .HasConstraintName("FK__permisos___id_pe__534D60F1");

            entity.HasOne(d => d.n_id_permisoNavigation).WithMany(p => p.permisos_perfils)
                .HasForeignKey(d => d.n_id_permiso)
                .HasConstraintName("FK__permisos___id_pe__5441852A");
        });

        modelBuilder.Entity<persona>(entity =>
        {
            entity.HasKey(e => e.n_id).HasName("PK__asistent__7371E14EC1BE642C");

            entity.ToTable("persona");

            entity.Property(e => e.v_apellidos)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.v_documento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.v_nombres)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<recurso>(entity =>
        {
            entity.HasKey(e => e.n_id).HasName("PK__recursos__7371E14E64B9DD21");

            entity.Property(e => e.n_estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.v_nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.v_observaciones).IsUnicode(false);

            entity.HasOne(d => d.n_categoria_parqueaderoNavigation).WithMany(p => p.recursos)
                .HasForeignKey(d => d.n_categoria_parqueadero)
                .HasConstraintName("FK__recursos__n_moda__4E53A1AA");

            entity.HasOne(d => d.n_nivel_recursoNavigation).WithMany(p => p.recursos)
                .HasForeignKey(d => d.n_nivel_recurso)
                .HasConstraintName("FK__recursos__n_nive__5224328E");

            entity.HasOne(d => d.n_tipo_recursoNavigation).WithMany(p => p.recursos)
                .HasForeignKey(d => d.n_tipo_recurso)
                .HasConstraintName("FK__recursos__n_tipo__4D5F7D71");
        });

        //modelBuilder.Entity<regional>(entity =>
        //{
        //    entity.HasKey(e => e.n_id).HasName("PK__regional__7371E14E6B0DB441");

        //    entity.ToTable("regional");

        //    entity.Property(e => e.d_fecha_actualiza).HasColumnType("datetime");
        //    entity.Property(e => e.d_fecha_crea)
        //        .HasDefaultValueSql("(getdate())")
        //        .HasColumnType("datetime");
        //    entity.Property(e => e.n_estado).HasDefaultValueSql("((1))");
        //    entity.Property(e => e.v_descripcion).HasMaxLength(70);

        //    entity.HasOne(d => d.n_id_usuario_actualizaNavigation).WithMany(p => p.regionaln_id_usuario_actualizaNavigations)
        //        .HasForeignKey(d => d.n_id_usuario_actualiza)
        //        .HasConstraintName("FK__regional__n_id_u__3296789C");

        //    entity.HasOne(d => d.n_id_usuario_creaNavigation).WithMany(p => p.regionaln_id_usuario_creaNavigations)
        //        .HasForeignKey(d => d.n_id_usuario_crea)
        //        .HasConstraintName("FK__regional__n_id_u__31A25463");

        //    entity.HasOne(d => d.n_id_usuario_sstNavigation).WithMany(p => p.regionaln_id_usuario_sstNavigations)
        //        .HasForeignKey(d => d.n_id_usuario_sst)
        //        .HasConstraintName("FK__regional__n_id_u__2A01329B");
        //});

        modelBuilder.Entity<reserva>(entity =>
        {
            entity.HasKey(e => e.n_id).HasName("PK__reservas__7371E14EA0F7393F");

            entity.Property(e => e.d_fecha_cancela).HasColumnType("datetime");
            entity.Property(e => e.n_estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.v_observaciones).IsUnicode(false);
            entity.Property(e => e.v_placa_vehiculo)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.n_id_recursoNavigation).WithMany(p => p.reservas)
                .HasForeignKey(d => d.n_id_recurso)
                .HasConstraintName("FK__reservas__n_id_r__3C34F16F");

            entity.HasOne(d => d.n_id_usuarioNavigation).WithMany(p => p.reservas)
                .HasForeignKey(d => d.n_id_usuario)
                .HasConstraintName("FK__reservas__n_id_u__3D2915A8");

            entity.HasOne(d => d.n_tipo_reservaNavigation).WithMany(p => p.reservas)
                .HasForeignKey(d => d.n_tipo_reserva)
                .HasConstraintName("FK__reservas__n_tipo__5F7E2DAC");
        });

        //modelBuilder.Entity<sede>(entity =>
        //{
        //    entity.HasKey(e => e.n_id).HasName("PK__activo__7371E14E055909F2");

        //    entity.ToTable("sede");

        //    entity.Property(e => e.n_estado).HasDefaultValueSql("((1))");
        //    entity.Property(e => e.n_solicitar_formato_ingreso)
        //        .HasDefaultValueSql("((0))")
        //        .HasComment("Determina si en solicitud de ingreso colaborador solicita formato de ingreso. ( 0 - No, 1 - Si)");
        //    entity.Property(e => e.n_solicitar_formato_vehiculos)
        //        .HasDefaultValueSql("((0))")
        //        .HasComment("Determina si en solicitud de ingreso colaborador solicita formato de vehiculo. ( 0 - No, 1 - Si)");
        //    entity.Property(e => e.n_solicitar_parafiscales)
        //        .HasDefaultValueSql("((0))")
        //        .HasComment("Determina si en solicitud de ingreso colaborador solicita parafiscales de los acompañantes. ( 0 - No, 1 - Si)");
        //    entity.Property(e => e.n_solicitar_petan).HasComment("Determina si en solicitud de ingreso solicita PETAN ( 0 - No, 1 - Si)");
        //    entity.Property(e => e.n_tipo)
        //        .HasDefaultValueSql("((0))")
        //        .HasComment("Deternima si es Subestación propia (0) o de Terceros (1)");

        //    entity.HasOne(d => d.n_id_regionalNavigation).WithMany(p => p.sedes)
        //        .HasForeignKey(d => d.n_id_regional)
        //        .HasConstraintName("FK__sede__n_id_regio__703EA55A");
        //});

        //modelBuilder.Entity<sede_area>(entity =>
        //{
        //    entity.HasKey(e => e.n_id).HasName("PK__subestac__7371E14EE702CC84");

        //    entity.ToTable("sede_area");

        //    entity.Property(e => e.n_estado).HasDefaultValueSql("((1))");

        //    entity.HasOne(d => d.n_id_areaNavigation).WithMany(p => p.sede_areas)
        //        .HasForeignKey(d => d.n_id_area)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK__subestaci__n_id___16CE6296");

        //    entity.HasOne(d => d.n_id_sedeNavigation).WithMany(p => p.sede_areas)
        //        .HasForeignKey(d => d.n_id_sede)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK_sede_area_sede");

        //    entity.HasOne(d => d.n_id_usuario_autorizaNavigation).WithMany(p => p.sede_areas)
        //        .HasForeignKey(d => d.n_id_usuario_autoriza)
        //        .HasConstraintName("FK__sede_area__n_id___1F83A428");
        //});

        //modelBuilder.Entity<solicitud_actividades>(entity =>
        //{
        //    entity.HasKey(e => e.n_id).HasName("PK__solicitu__7371E14E81793233");

        //    entity.Property(e => e.v_condicion_ope).IsUnicode(false);
        //    entity.Property(e => e.v_planeacion).IsUnicode(false);

        //    entity.HasOne(d => d.n_id_solicitudNavigation).WithMany(p => p.solicitud_actividades)
        //        .HasForeignKey(d => d.n_id_solicitud)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK__solicitud__n_id___68487DD7");
        //});

        //modelBuilder.Entity<solicitud_area>(entity =>
        //{
        //    entity.HasKey(e => e.n_id).HasName("PK__solicitu__7371E14EE5B732E3");

        //    entity.ToTable("solicitud_area");

        //    entity.Property(e => e.d_fecha_aprobacion).HasColumnType("datetime");
        //    entity.Property(e => e.n_estado)
        //        .HasDefaultValueSql("((1))")
        //        .HasComment("Determina el estado de aprobación de la solicitud de areas (0 - Anulada, 1- Pendiente, 2- Rechazada, 3 - Aprobada )");
        //    entity.Property(e => e.v_observa_aprobacion).IsUnicode(false);

        //    entity.HasOne(d => d.n_id_solicitudNavigation).WithMany(p => p.solicitud_areas)
        //        .HasForeignKey(d => d.n_id_solicitud)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK__solicitud__n_id___1A9EF37A");

        //    entity.HasOne(d => d.n_id_subestacion_areaNavigation).WithMany(p => p.solicitud_areas)
        //        .HasForeignKey(d => d.n_id_subestacion_area)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK__solicitud__n_id___1B9317B3");

        //    entity.HasOne(d => d.n_id_usuario_aprobNavigation).WithMany(p => p.solicitud_areas)
        //        .HasForeignKey(d => d.n_id_usuario_aprob)
        //        .HasConstraintName("FK__solicitud__n_id___290D0E62");
        //});

        //modelBuilder.Entity<solicitud_asistente>(entity =>
        //{
        //    entity.HasKey(e => e.n_id).HasName("PK__solicitu__7371E14E38362A14");

        //    entity.Property(e => e.n_alturas).HasDefaultValueSql("((0))");
        //    entity.Property(e => e.n_conte).HasDefaultValueSql("((0))");
        //    entity.Property(e => e.n_copnia).HasDefaultValueSql("((0))");
        //    entity.Property(e => e.v_archivo_parafiscal).IsUnicode(false);
        //    entity.Property(e => e.v_empresa)
        //        .HasMaxLength(100)
        //        .IsUnicode(false);

        //    entity.HasOne(d => d.n_id_arlNavigation).WithMany(p => p.solicitud_asistentes)
        //        .HasForeignKey(d => d.n_id_arl)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK__solicitud__n_id___74AE54BC");

        //    entity.HasOne(d => d.n_id_asistenteNavigation).WithMany(p => p.solicitud_asistentes)
        //        .HasForeignKey(d => d.n_id_asistente)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK__solicitud__n_id___72C60C4A");

        //    entity.HasOne(d => d.n_id_epsNavigation).WithMany(p => p.solicitud_asistentes)
        //        .HasForeignKey(d => d.n_id_eps)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK__solicitud__n_id___73BA3083");

        //    entity.HasOne(d => d.n_id_roleNavigation).WithMany(p => p.solicitud_asistentes)
        //        .HasForeignKey(d => d.n_id_role)
        //        .HasConstraintName("FK__solicitud__n_id___75A278F5");

        //    entity.HasOne(d => d.n_id_solicitudNavigation).WithMany(p => p.solicitud_asistentes)
        //        .HasForeignKey(d => d.n_id_solicitud)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK__solicitud__n_id___71D1E811");
        //});

        //modelBuilder.Entity<solicitud_cabecera>(entity =>
        //{
        //    entity.HasKey(e => e.n_id).HasName("PK__solicitu__7371E14ED33DFA07");

        //    entity.ToTable("solicitud_cabecera");

        //    entity.Property(e => e.d_fecha_actualiza).HasColumnType("datetime");
        //    entity.Property(e => e.d_fecha_aprobacion1)
        //        .HasComment("Aprobación de surpervisor")
        //        .HasColumnType("datetime");
        //    entity.Property(e => e.d_fecha_aprobacion2)
        //        .HasComment("Aprobación de areas")
        //        .HasColumnType("datetime");
        //    entity.Property(e => e.d_fecha_aprobacion3)
        //        .HasComment("Aprobación de SST")
        //        .HasColumnType("datetime");
        //    entity.Property(e => e.d_fecha_aprobacion4)
        //        .HasComment("Aprobación por Gerenccia de Operaciones cuando es Subestación de Terceros")
        //        .HasColumnType("datetime");
        //    entity.Property(e => e.d_fecha_fin).HasColumnType("datetime");
        //    entity.Property(e => e.d_fecha_inicio).HasColumnType("datetime");
        //    entity.Property(e => e.d_fecha_registro)
        //        .HasDefaultValueSql("(getdate())")
        //        .HasColumnType("datetime");
        //    entity.Property(e => e.n_equipo_desenergizado).HasDefaultValueSql("((0))");
        //    entity.Property(e => e.n_equipo_energizado).HasDefaultValueSql("((0))");
        //    entity.Property(e => e.n_estado)
        //        .HasDefaultValueSql("((1))")
        //        .HasComment("Define el estado general de la solicitud, 0 - Anulada, 1 - Vigente, 2 - Rechazada, 3 - Aprobada");
        //    entity.Property(e => e.n_estado_aprobacion1)
        //        .HasDefaultValueSql("((1))")
        //        .HasComment("Define Aprobación de surpervisor (nivel 1) de la solicitud, 0 -Anulada , 1 - Pendiente, 2 - Rechazada, 3 - Aprobada");
        //    entity.Property(e => e.n_estado_aprobacion2)
        //        .HasDefaultValueSql("((1))")
        //        .HasComment("Define Aprobación de areas (nivel 2) de la solicitud, 0 -Anulada , 1 - Pendiente, 2 - Rechazada, 3 - Aprobada");
        //    entity.Property(e => e.n_estado_aprobacion3)
        //        .HasDefaultValueSql("((1))")
        //        .HasComment("Define Aprobación de SST (nivel 3) de la solicitud, 0 -Anulada , 1 - Pendiente, 2 - Rechazada, 3 - Aprobada");
        //    entity.Property(e => e.n_estado_aprobacion4)
        //        .HasDefaultValueSql("((1))")
        //        .HasComment("Define Aprobación por Gerenccia de Operaciones cuando es Subestación de Terceros (nivel 4) de la solicitud, 0 -Anulada , 1 - Pendiente, 2 - Rechazada, 3 - Aprobada");
        //    entity.Property(e => e.n_id_empresa_solicitante).HasComment("almacena el nombre de la empresa solicitante (GEB(1) o Enlaza(2))");
        //    entity.Property(e => e.n_id_usuario_aprob1).HasComment("Aprobación de surpervisor");
        //    entity.Property(e => e.n_id_usuario_aprob2).HasComment("Aprobación de areas");
        //    entity.Property(e => e.n_id_usuario_aprob3).HasComment("Aprobación de SST");
        //    entity.Property(e => e.n_id_usuario_aprob4).HasComment("Aprobación por Gerenccia de Operaciones cuando es Subestación de Terceros");
        //    entity.Property(e => e.n_req_escolta).HasDefaultValueSql("((0))");
        //    entity.Property(e => e.n_riesgo_diparo).HasDefaultValueSql("((0))");
        //    entity.Property(e => e.n_ta_m1).HasDefaultValueSql("((0))");
        //    entity.Property(e => e.n_ta_m2).HasDefaultValueSql("((0))");
        //    entity.Property(e => e.n_ta_m3).HasDefaultValueSql("((0))");
        //    entity.Property(e => e.n_ta_m4).HasDefaultValueSql("((0))");
        //    entity.Property(e => e.n_ta_m5).HasDefaultValueSql("((0))");
        //    entity.Property(e => e.n_tipo_solicitud)
        //        .HasDefaultValueSql("((1))")
        //        .HasComment("Define si es solicitud de ingreso para Contratista (1) o para colaborador (2)");
        //    entity.Property(e => e.n_trabajo_emergencia).HasDefaultValueSql("((0))");
        //    entity.Property(e => e.n_trabajo_planeado).HasDefaultValueSql("((0))");
        //    entity.Property(e => e.n_trabajo_planeado_simul).HasDefaultValueSql("((0))");
        //    entity.Property(e => e.v_emergencia_direccion)
        //        .HasMaxLength(100)
        //        .IsUnicode(false);
        //    entity.Property(e => e.v_emergencia_lugar)
        //        .HasMaxLength(100)
        //        .IsUnicode(false);
        //    entity.Property(e => e.v_emergencia_telefono)
        //        .HasMaxLength(30)
        //        .IsUnicode(false);
        //    entity.Property(e => e.v_empresa_ejecuta)
        //        .HasMaxLength(100)
        //        .IsUnicode(false);
        //    entity.Property(e => e.v_equipo_identificacion).IsUnicode(false);
        //    entity.Property(e => e.v_n_plan_trabajo)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);
        //    entity.Property(e => e.v_n_ticket)
        //        .HasMaxLength(100)
        //        .IsUnicode(false);
        //    entity.Property(e => e.v_nacional).IsUnicode(false);
        //    entity.Property(e => e.v_nom_escolta)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);
        //    entity.Property(e => e.v_nombre_archivo_formato_ingreso).IsUnicode(false);
        //    entity.Property(e => e.v_nombre_archivo_formato_vehiculos).IsUnicode(false);
        //    entity.Property(e => e.v_nombre_archivo_parafiscal).IsUnicode(false);
        //    entity.Property(e => e.v_nombre_archivo_ptam).IsUnicode(false);
        //    entity.Property(e => e.v_nombre_archivo_ptam_definitivo).IsUnicode(false);
        //    entity.Property(e => e.v_observa_aprobacion1)
        //        .IsUnicode(false)
        //        .HasComment("Aprobación de surpervisor");
        //    entity.Property(e => e.v_observa_aprobacion2)
        //        .IsUnicode(false)
        //        .HasComment("Aprobación de areas");
        //    entity.Property(e => e.v_observa_aprobacion3)
        //        .IsUnicode(false)
        //        .HasComment("Aprobación de SST");
        //    entity.Property(e => e.v_observa_aprobacion4)
        //        .IsUnicode(false)
        //        .HasComment("Aprobación por Gerenccia de Operaciones cuando es Subestación de Terceros");
        //    entity.Property(e => e.v_observaciones).IsUnicode(false);
        //    entity.Property(e => e.v_regional).IsUnicode(false);
        //    entity.Property(e => e.v_telefono)
        //        .HasMaxLength(30)
        //        .IsUnicode(false);
        //    entity.Property(e => e.v_trabajo_a_realizar).IsUnicode(false);
        //    entity.Property(e => e.v_url_share_point).IsUnicode(false);

        //    entity.HasOne(d => d.n_id_contratoNavigation).WithMany(p => p.solicitud_cabeceras)
        //        .HasForeignKey(d => d.n_id_contrato)
        //        .HasConstraintName("FK__solicitud__n_id___39237A9A");

        //    entity.HasOne(d => d.n_id_sedeNavigation).WithMany(p => p.solicitud_cabeceras)
        //        .HasForeignKey(d => d.n_id_sede)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK__solicitud__n_id___7132C993");

        //    entity.HasOne(d => d.n_id_usuario_actuNavigation).WithMany(p => p.solicitud_cabeceran_id_usuario_actuNavigations)
        //        .HasForeignKey(d => d.n_id_usuario_actu)
        //        .HasConstraintName("FK__solicitud__n_id___6383C8BA");

        //    entity.HasOne(d => d.n_id_usuario_aprob1Navigation).WithMany(p => p.solicitud_cabeceran_id_usuario_aprob1Navigations)
        //        .HasForeignKey(d => d.n_id_usuario_aprob1)
        //        .HasConstraintName("FK__solicitud__n_id___6477ECF3");

        //    entity.HasOne(d => d.n_id_usuario_aprob2Navigation).WithMany(p => p.solicitud_cabeceran_id_usuario_aprob2Navigations)
        //        .HasForeignKey(d => d.n_id_usuario_aprob2)
        //        .HasConstraintName("FK__solicitud__n_id___656C112C");

        //    entity.HasOne(d => d.n_id_usuario_aprob3Navigation).WithMany(p => p.solicitud_cabeceran_id_usuario_aprob3Navigations)
        //        .HasForeignKey(d => d.n_id_usuario_aprob3)
        //        .HasConstraintName("FK__solicitud__n_id___2B5F6B28");

        //    entity.HasOne(d => d.n_id_usuario_aprob4Navigation).WithMany(p => p.solicitud_cabeceran_id_usuario_aprob4Navigations)
        //        .HasForeignKey(d => d.n_id_usuario_aprob4)
        //        .HasConstraintName("FK__solicitud__n_id___2C538F61");

        //    entity.HasOne(d => d.n_id_usuario_regiNavigation).WithMany(p => p.solicitud_cabeceran_id_usuario_regiNavigations)
        //        .HasForeignKey(d => d.n_id_usuario_regi)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK__solicitud__n_id___628FA481");
        //});

        //modelBuilder.Entity<solicitud_medidas_seguridad>(entity =>
        //{
        //    entity.HasKey(e => e.n_id).HasName("PK__solicitu__7371E14EEF33E1A8");

        //    entity.ToTable("solicitud_medidas_seguridad");

        //    entity.Property(e => e.v_descripcion).IsUnicode(false);

        //    entity.HasOne(d => d.n_id_solicitudNavigation).WithMany(p => p.solicitud_medidas_seguridads)
        //        .HasForeignKey(d => d.n_id_solicitud)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK__solicitud__n_id___6B24EA82");
        //});

        //modelBuilder.Entity<solicitud_rol>(entity =>
        //{
        //    entity.HasKey(e => e.n_id).HasName("PK__solicitu__7371E14EAA33E8FF");

        //    entity.ToTable("solicitud_rol");

        //    entity.Property(e => e.v_descripcion)
        //        .HasMaxLength(100)
        //        .IsUnicode(false);
        //});

        //modelBuilder.Entity<solicitud_vehiculo>(entity =>
        //{
        //    entity.HasKey(e => e.n_id).HasName("PK__solicitu__7371E14E8A7170D9");

        //    entity.ToTable("solicitud_vehiculo");

        //    entity.Property(e => e.v_descripcion).IsUnicode(false);
        //    entity.Property(e => e.v_fecha_cert_operador)
        //        .HasMaxLength(100)
        //        .IsUnicode(false);
        //    entity.Property(e => e.v_fecha_certifi)
        //        .HasMaxLength(100)
        //        .IsUnicode(false);
        //    entity.Property(e => e.v_marca)
        //        .HasMaxLength(30)
        //        .IsUnicode(false);
        //    entity.Property(e => e.v_placa)
        //        .HasMaxLength(30)
        //        .IsUnicode(false);

        //    entity.HasOne(d => d.n_id_solicitudNavigation).WithMany(p => p.solicitud_vehiculos)
        //        .HasForeignKey(d => d.n_id_solicitud)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK__solicitud__n_id___787EE5A0");
        //});

        modelBuilder.Entity<tipos_recurso>(entity =>
        {
            entity.HasKey(e => e.n_id).HasName("PK__tipos_re__7371E14E979742CC");

            entity.ToTable("tipos_recurso");

            entity.Property(e => e.n_estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.v_descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tipos_reserva>(entity =>
        {
            entity.HasKey(e => e.n_id).HasName("PK__tipos_re__7371E14E017050C2");

            entity.ToTable("tipos_reserva");

            entity.Property(e => e.n_estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.v_descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<usuario>(entity =>
        {
            entity.HasKey(e => e.n_id).HasName("PK__usuarios__3213E83FC8D31053");

            entity.HasIndex(e => e.n_id_perfil, "IX_usuarios_id_perfil");

            entity.Property(e => e.n_estado).HasDefaultValueSql("((1))");
            entity.Property(e => e.n_id_contrato).HasComment("Se asigna contrato cuando es contratista");
            entity.Property(e => e.n_id_subestacion).HasComment("Se asigna subestación cuando es colaborador");
            entity.Property(e => e.v_clave).IsUnicode(false);
            entity.Property(e => e.v_correo).IsUnicode(false);
            entity.Property(e => e.v_usuario)
                .HasMaxLength(50)
                .IsUnicode(false);

            //entity.HasOne(d => d.n_id_contratoNavigation).WithMany(p => p.usuarios)
            //    .HasForeignKey(d => d.n_id_contrato)
            //    .HasConstraintName("FK__usuarios__n_id_c__10216507");

            entity.HasOne(d => d.n_id_perfilNavigation).WithMany(p => p.usuarios)
                .HasForeignKey(d => d.n_id_perfil)
                .HasConstraintName("FK__usuarios__id_per__5EBF139D");

            entity.HasOne(d => d.n_id_personaNavigation).WithMany(p => p.usuarios)
                .HasForeignKey(d => d.n_id_persona)
                .HasConstraintName("FK__usuarios__n_id_p__2022C2A6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
