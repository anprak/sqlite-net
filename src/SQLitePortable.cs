//
// Copyright (c) 2009-2012 Krueger Systems, Inc.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

using System;

namespace SQLite
{
	[Flags]
	public enum SQLiteOpenFlags {
		ReadOnly = 1, ReadWrite = 2, Create = 4,
		NoMutex = 0x8000, FullMutex = 0x10000,
		SharedCache = 0x20000, PrivateCache = 0x40000,
		ProtectionComplete = 0x00100000,
		ProtectionCompleteUnlessOpen = 0x00200000,
		ProtectionCompleteUntilFirstUserAuthentication = 0x00300000,
		ProtectionNone = 0x00400000
	}

    [Flags]
    public enum CreateFlags
    {
        None = 0,
        ImplicitPK = 1,    // create a primary key for field called 'Id' (Orm.ImplicitPkName)
        ImplicitIndex = 2, // create an index for fields ending in 'Id' (Orm.ImplicitIndexSuffix)
        AllImplicit = 3,   // do both above

        AutoIncPK = 4      // force PK field to be auto inc
    }

    [AttributeUsage (AttributeTargets.Class)]
	public class TableAttribute : Attribute
	{
		public string Name { get; set; }

		public TableAttribute (string name)
		{
			Name = name;
		}
	}

	[AttributeUsage (AttributeTargets.Property)]
	public class ColumnAttribute : Attribute
	{
		public string Name { get; set; }

		public ColumnAttribute (string name)
		{
			Name = name;
		}
	}

	[AttributeUsage (AttributeTargets.Property)]
	public class PrimaryKeyAttribute : Attribute
	{
	}

	[AttributeUsage (AttributeTargets.Property)]
	public class AutoIncrementAttribute : Attribute
	{
	}

	[AttributeUsage (AttributeTargets.Property)]
	public class IndexedAttribute : Attribute
	{
		public string Name { get; set; }
		public int Order { get; set; }
		public virtual bool Unique { get; set; }
		
		public IndexedAttribute()
		{
		}
		
		public IndexedAttribute(string name, int order)
		{
			Name = name;
			Order = order;
		}
	}

	[AttributeUsage (AttributeTargets.Property)]
	public class IgnoreAttribute : Attribute
	{
	}

	[AttributeUsage (AttributeTargets.Property)]
	public class UniqueAttribute : IndexedAttribute
	{
		public override bool Unique {
			get { return true; }
			set { /* throw?  */ }
		}
	}

	[AttributeUsage (AttributeTargets.Property)]
	public class MaxLengthAttribute : Attribute
	{
		public int Value { get; private set; }

		public MaxLengthAttribute (int length)
		{
			Value = length;
		}
	}

	[AttributeUsage (AttributeTargets.Property)]
	public class CollationAttribute: Attribute
	{
		public string Value { get; private set; }

		public CollationAttribute (string collation)
		{
			Value = collation;
		}
	}
}
