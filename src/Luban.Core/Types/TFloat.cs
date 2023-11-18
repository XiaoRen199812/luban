using Luban.TypeVisitors;

namespace Luban.Types;

public class TFloat : TType
{
    public static TFloat Ins { get; } = new(false, null);

    public static TFloat Create(bool isNullable, Dictionary<string, string> tags)
    {
        return new TFloat(isNullable, tags);
    }

    public override string TypeName => "float";

    private TFloat(bool isNullable, Dictionary<string, string> tags) : base(isNullable, tags)
    {
    }

    public override bool TryParseFrom(string s)
    {
        return float.TryParse(s, out _);
    }

    public override void Apply<T>(ITypeActionVisitor<T> visitor, T x)
    {
        visitor.Accept(this, x);
    }

    public override void Apply<T1, T2>(ITypeActionVisitor<T1, T2> visitor, T1 x, T2 y)
    {
        visitor.Accept(this, x, y);
    }

    public override TR Apply<TR>(ITypeFuncVisitor<TR> visitor)
    {
        return visitor.Accept(this);
    }

    public override TR Apply<T, TR>(ITypeFuncVisitor<T, TR> visitor, T x)
    {
        return visitor.Accept(this, x);
    }

    public override TR Apply<T1, T2, TR>(ITypeFuncVisitor<T1, T2, TR> visitor, T1 x, T2 y)
    {
        return visitor.Accept(this, x, y);
    }

    public override TR Apply<T1, T2, T3, TR>(ITypeFuncVisitor<T1, T2, T3, TR> visitor, T1 x, T2 y, T3 z)
    {
        return visitor.Accept(this, x, y, z);
    }
}
