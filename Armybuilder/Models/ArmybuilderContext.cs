using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ArmyBuilder.Models;

public partial class ArmybuilderContext : DbContext
{
    public ArmybuilderContext()
    {
    }

    public ArmybuilderContext(DbContextOptions<ArmybuilderContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Army> Armies { get; set; }

    public virtual DbSet<ArmyDetachment> ArmyDetachments { get; set; }

    public virtual DbSet<Detachment> Detachments { get; set; }

    public virtual DbSet<DetachmentRule> DetachmentRules { get; set; }

    public virtual DbSet<DetachmentUnit> DetachmentUnits { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<EquipmentRule> EquipmentRules { get; set; }

    public virtual DbSet<Faction> Factions { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<ModelEquipment> ModelEquipments { get; set; }

    public virtual DbSet<Rule> Rules { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<UnitCost> UnitCosts { get; set; }

    public virtual DbSet<UnitRule> UnitRules { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost; uid=root; pwd=Password123!; database=armybuilder");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Army>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("army");

            entity.HasIndex(e => e.FkUserId, "FK3vfn1uwvjmqcacl060a2fbxcr");

            entity.HasIndex(e => e.FkFactionId, "FK49xi3qh9t6sba3dbrs13il54k");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ArmyName)
                .HasMaxLength(255)
                .HasColumnName("army_name");
            entity.Property(e => e.FkFactionId).HasColumnName("fk_faction_id");
            entity.Property(e => e.FkUserId).HasColumnName("fk_user_id");

            entity.HasOne(d => d.FkFaction).WithMany(p => p.Armies)
                .HasForeignKey(d => d.FkFactionId)
                .HasConstraintName("FK49xi3qh9t6sba3dbrs13il54k");

            entity.HasOne(d => d.FkUser).WithMany(p => p.Armies)
                .HasForeignKey(d => d.FkUserId)
                .HasConstraintName("FK3vfn1uwvjmqcacl060a2fbxcr");
        });

        modelBuilder.Entity<ArmyDetachment>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("army_detachments");

            entity.HasIndex(e => e.DetachmentsDetachmentId, "FKb225732m40bugs7choh63uap6");

            entity.HasIndex(e => e.ArmyId, "FKjlv3eu3h2jdot3ks70up95a7t");

            entity.Property(e => e.ArmyId).HasColumnName("army_id");
            entity.Property(e => e.DetachmentsDetachmentId).HasColumnName("detachments_detachment_id");

            entity.HasOne(d => d.Army).WithMany()
                .HasForeignKey(d => d.ArmyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKjlv3eu3h2jdot3ks70up95a7t");

            entity.HasOne(d => d.DetachmentsDetachment).WithMany()
                .HasForeignKey(d => d.DetachmentsDetachmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKb225732m40bugs7choh63uap6");
        });

        modelBuilder.Entity<Detachment>(entity =>
        {
            entity.HasKey(e => e.DetachmentId).HasName("PRIMARY");

            entity.ToTable("detachment");

            entity.Property(e => e.DetachmentId).HasColumnName("detachment_id");
            entity.Property(e => e.DetachmentName)
                .HasMaxLength(255)
                .HasColumnName("detachment_name");
        });

        modelBuilder.Entity<DetachmentRule>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("detachment_rules");

            entity.HasIndex(e => e.RulesRuleId, "FK1jr4njr4vmcsvuv5jnvtm37ag");

            entity.HasIndex(e => e.DetachmentDetachmentId, "FKf0mx4bf2sx0ja935h27s3y3md");

            entity.Property(e => e.DetachmentDetachmentId).HasColumnName("detachment_detachment_id");
            entity.Property(e => e.RulesRuleId).HasColumnName("rules_rule_id");

            entity.HasOne(d => d.DetachmentDetachment).WithMany()
                .HasForeignKey(d => d.DetachmentDetachmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKf0mx4bf2sx0ja935h27s3y3md");

            entity.HasOne(d => d.RulesRule).WithMany()
                .HasForeignKey(d => d.RulesRuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK1jr4njr4vmcsvuv5jnvtm37ag");
        });

        modelBuilder.Entity<DetachmentUnit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("detachment_unit");

            entity.HasIndex(e => e.DetachmentId, "FK3l3ud88yshgolvykx8n7g9tjl");

            entity.HasIndex(e => e.UnitId, "FKbjgdwln7wgrqj0umf7aok6xup");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DetachmentId).HasColumnName("detachment_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UnitId).HasColumnName("unit_id");

            entity.HasOne(d => d.Detachment).WithMany(p => p.DetachmentUnits)
                .HasForeignKey(d => d.DetachmentId)
                .HasConstraintName("FK3l3ud88yshgolvykx8n7g9tjl");

            entity.HasOne(d => d.Unit).WithMany(p => p.DetachmentUnits)
                .HasForeignKey(d => d.UnitId)
                .HasConstraintName("FKbjgdwln7wgrqj0umf7aok6xup");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.EquipmentId).HasName("PRIMARY");

            entity.ToTable("equipment");

            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            entity.Property(e => e.ArmourPenetration)
                .HasMaxLength(255)
                .HasColumnName("armour penetration");
            entity.Property(e => e.Attacks)
                .HasMaxLength(255)
                .HasColumnName("attacks");
            entity.Property(e => e.BallisticSkill)
                .HasMaxLength(255)
                .HasColumnName("ballistic_skill");
            entity.Property(e => e.Damage)
                .HasMaxLength(255)
                .HasColumnName("damage");
            entity.Property(e => e.EquipmentName)
                .HasMaxLength(255)
                .HasColumnName("equipment_name");
            entity.Property(e => e.Keywords)
                .HasMaxLength(255)
                .HasColumnName("keywords");
            entity.Property(e => e.PointCost).HasColumnName("point_cost");
            entity.Property(e => e.Range)
                .HasMaxLength(255)
                .HasColumnName("range");
            entity.Property(e => e.Strength)
                .HasMaxLength(255)
                .HasColumnName("strength");
        });

        modelBuilder.Entity<EquipmentRule>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("equipment_rules");

            entity.HasIndex(e => e.EquipmentEquipmentId, "FK3dt5kxdm0bvi43k5elwrf326");

            entity.HasIndex(e => e.RulesRuleId, "FK6f81iq27m5ai90tgo5ooo48ai");

            entity.Property(e => e.EquipmentEquipmentId).HasColumnName("equipment_equipment_id");
            entity.Property(e => e.RulesRuleId).HasColumnName("rules_rule_id");

            entity.HasOne(d => d.EquipmentEquipment).WithMany()
                .HasForeignKey(d => d.EquipmentEquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK3dt5kxdm0bvi43k5elwrf326");

            entity.HasOne(d => d.RulesRule).WithMany()
                .HasForeignKey(d => d.RulesRuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK6f81iq27m5ai90tgo5ooo48ai");
        });

        modelBuilder.Entity<Faction>(entity =>
        {
            entity.HasKey(e => e.FactionId).HasName("PRIMARY");

            entity.ToTable("faction");

            entity.Property(e => e.FactionId).HasColumnName("faction_id");
            entity.Property(e => e.FactionName)
                .HasMaxLength(255)
                .HasColumnName("faction_name");
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => e.ModelId).HasName("PRIMARY");

            entity.ToTable("model");

            entity.HasIndex(e => e.FkModelId, "FKldj3vn0r54h0g4hjxmwfswj93");

            entity.Property(e => e.ModelId).HasColumnName("model_id");
            entity.Property(e => e.FkModelId).HasColumnName("fk_model_id");
            entity.Property(e => e.Leadership).HasColumnName("leadership");
            entity.Property(e => e.ModelName)
                .HasMaxLength(255)
                .HasColumnName("model_name");
            entity.Property(e => e.Movement).HasColumnName("movement");
            entity.Property(e => e.ObjectiveControl).HasColumnName("objective_control");
            entity.Property(e => e.Save).HasColumnName("save");
            entity.Property(e => e.Toughness).HasColumnName("toughness");
            entity.Property(e => e.Wound).HasColumnName("wound");

            entity.HasOne(d => d.FkModel).WithMany(p => p.Models)
                .HasForeignKey(d => d.FkModelId)
                .HasConstraintName("FKldj3vn0r54h0g4hjxmwfswj93");
        });

        modelBuilder.Entity<ModelEquipment>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("model_equipments");

            entity.HasIndex(e => e.ModelModelId, "FK2c0adculmfww89yb4ipwup07q");

            entity.HasIndex(e => e.EquipmentsEquipmentId, "FKgrkymosyf56ttvcrgu6lsp6w6");

            entity.Property(e => e.EquipmentsEquipmentId).HasColumnName("equipments_equipment_id");
            entity.Property(e => e.ModelModelId).HasColumnName("model_model_id");

            entity.HasOne(d => d.EquipmentsEquipment).WithMany()
                .HasForeignKey(d => d.EquipmentsEquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKgrkymosyf56ttvcrgu6lsp6w6");

            entity.HasOne(d => d.ModelModel).WithMany()
                .HasForeignKey(d => d.ModelModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK2c0adculmfww89yb4ipwup07q");
        });

        modelBuilder.Entity<Rule>(entity =>
        {
            entity.HasKey(e => e.RuleId).HasName("PRIMARY");

            entity.ToTable("rule");

            entity.Property(e => e.RuleId).HasColumnName("rule_id");
            entity.Property(e => e.RuleDescription)
                .HasMaxLength(1000)
                .HasColumnName("rule_description");
            entity.Property(e => e.RuleName)
                .HasMaxLength(255)
                .HasColumnName("rule_name");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.UnitId).HasName("PRIMARY");

            entity.ToTable("unit");

            entity.HasIndex(e => e.FkFactionId, "FKhfg73k595rex9hpc9fdgxppmp");

            entity.Property(e => e.UnitId).HasColumnName("unit_id");
            entity.Property(e => e.FkFactionId).HasColumnName("fk_faction_id");
            entity.Property(e => e.UnitName)
                .HasMaxLength(255)
                .HasColumnName("unit_name");
            entity.Property(e => e.UnitRole)
                .HasMaxLength(255)
                .HasColumnName("unit_role");

            entity.HasOne(d => d.FkFaction).WithMany(p => p.Units)
                .HasForeignKey(d => d.FkFactionId)
                .HasConstraintName("FKhfg73k595rex9hpc9fdgxppmp");
        });

        modelBuilder.Entity<UnitCost>(entity =>
        {
            entity.HasKey(e => e.UnitCostId).HasName("PRIMARY");

            entity.ToTable("unit_cost");

            entity.HasIndex(e => e.FkUnitCostId, "FKnldaf632jhhvaadgyv0mji2ju");

            entity.Property(e => e.UnitCostId).HasColumnName("unit_cost_id");
            entity.Property(e => e.FkUnitCostId).HasColumnName("fk_unit_cost_id");
            entity.Property(e => e.ModelCount).HasColumnName("model_count");
            entity.Property(e => e.PointCost).HasColumnName("point_cost");

            entity.HasOne(d => d.FkUnitCost).WithMany(p => p.UnitCosts)
                .HasForeignKey(d => d.FkUnitCostId)
                .HasConstraintName("FKnldaf632jhhvaadgyv0mji2ju");
        });

        modelBuilder.Entity<UnitRule>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("unit_rules");

            entity.HasIndex(e => e.UnitUnitId, "FK3rm9og1dnmqo0xy4fhxnxe1i5");

            entity.HasIndex(e => e.RulesRuleId, "FKtq8qtxqvr1y2hb3gm99ww8988");

            entity.Property(e => e.RulesRuleId).HasColumnName("rules_rule_id");
            entity.Property(e => e.UnitUnitId).HasColumnName("unit_unit_id");

            entity.HasOne(d => d.RulesRule).WithMany()
                .HasForeignKey(d => d.RulesRuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKtq8qtxqvr1y2hb3gm99ww8988");

            entity.HasOne(d => d.UnitUnit).WithMany()
                .HasForeignKey(d => d.UnitUnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK3rm9og1dnmqo0xy4fhxnxe1i5");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Roles)
                .HasMaxLength(255)
                .HasColumnName("roles");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
