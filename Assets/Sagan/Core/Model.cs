namespace Sagan.Core
{
  using global::System;
  using global::FlatBuffers;

  public struct Sword : IFlatbufferObject
  {
    private Table __p;
    public ByteBuffer ByteBuffer { get { return __p.bb; } }

    public static Sword GetRootAsSword(ByteBuffer _bb)
    {
      return GetRootAsSword(_bb, new Sword());
    }

    public static Sword GetRootAsSword(ByteBuffer _bb, Sword obj)
    {
      return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb));
    }

    public static bool SwordBufferHasIdentifier(ByteBuffer _bb)
    {
      return Table.__has_identifier(_bb, "WHAT");
    }

    public void __init(int _i, ByteBuffer _bb)
    {
      __p.bb_pos = _i; __p.bb = _bb;
    }

    public Sword __assign(int _i, ByteBuffer _bb)
    {
      __init(_i, _bb); return this;
    }

    public int Damage { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)10; } }
    public short Distance { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetShort(o + __p.bb_pos) : (short)5; } }

    public static Offset<Sword> CreateSword(FlatBufferBuilder builder,
        int damage = 10,
        short distance = 5)
    {
      builder.StartObject(2);
      Sword.AddDamage(builder, damage);
      Sword.AddDistance(builder, distance);
      return Sword.EndSword(builder);
    }

    public static void StartSword(FlatBufferBuilder builder)
    {
      builder.StartObject(2);
    }

    public static void AddDamage(FlatBufferBuilder builder, int damage)
    {
      builder.AddInt(0, damage, 10);
    }

    public static void AddDistance(FlatBufferBuilder builder, short distance)
    {
      builder.AddShort(1, distance, 5);
    }

    public static Offset<Sword> EndSword(FlatBufferBuilder builder)
    {
      int o = builder.EndObject();
      return new Offset<Sword>(o);
    }

    public static void FinishSwordBuffer(FlatBufferBuilder builder, Offset<Sword> offset)
    {
      builder.Finish(offset.Value, "WHAT");
    }
  };
}