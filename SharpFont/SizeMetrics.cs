﻿#region MIT License
/*Copyright (c) 2012 Robert Rouhani <robert.rouhani@gmail.com>

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
of the Software, and to permit persons to whom the Software is furnished to do
so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.*/
#endregion

using System;
using System.Runtime.InteropServices;

namespace SharpFont
{
	/// <summary>
	/// The size metrics structure gives the metrics of a size object.
	/// </summary>
	/// <remarks>
	/// The scaling values, if relevant, are determined first during a size
	/// changing operation. The remaining fields are then set by the driver.
	/// For scalable formats, they are usually set to scaled values of the
	/// corresponding fields in <see cref="Face"/>.
	/// 
	/// Note that due to glyph hinting, these values might not be exact for
	/// certain fonts. Thus they must be treated as unreliable with an error
	/// margin of at least one pixel!
	/// 
	/// Indeed, the only way to get the exact metrics is to render all glyphs.
	/// As this would be a definite performance hit, it is up to client
	/// applications to perform such computations.
	/// 
	/// The SizeMetrics structure is valid for bitmap fonts also.
	/// </remarks>
	public sealed class SizeMetrics
	{
		internal IntPtr reference;

		public SizeMetrics(IntPtr reference)
		{
			this.reference = reference;
		}

		/// <summary>
		/// The width of the scaled EM square in pixels, hence the term ‘ppem’
		/// (pixels per EM). It is also referred to as ‘nominal width’.
		/// </summary>
		public ushort NominalWidth
		{
			get
			{
				return (ushort)Marshal.ReadInt16(reference + 0);
			}
		}

		/// <summary>
		/// The height of the scaled EM square in pixels, hence the term ‘ppem’
		/// (pixels per EM). It is also referred to as ‘nominal width’.
		/// </summary>
		public ushort NominalHeight
		{
			get
			{
				return (ushort)Marshal.ReadInt16(reference + 2);
			}
		}

		/// <summary>
		/// A 16.16 fractional scaling value used to convert horizontal metrics
		/// from font units to 26.6 fractional pixels. Only relevant for
		/// scalable font formats.
		/// </summary>
		public int ScaleX
		{
			get
			{
				return Marshal.ReadInt32(reference + 4);
			}
		}

		/// <summary>
		/// A 16.16 fractional scaling value used to convert vertical metrics
		/// from font units to 26.6 fractional pixels. Only relevant for
		/// scalable font formats.
		/// </summary>
		public int ScaleY
		{
			get
			{
				return Marshal.ReadInt32(reference + 8);
			}
		}

		/// <summary>
		/// The ascender in 26.6 fractional pixels.
		/// </summary>
		/// <see cref="Face"/>
		public int Ascender
		{
			get
			{
				return Marshal.ReadInt32(reference + 12);
			}
		}

		/// <summary>
		/// The descender in 26.6 fractional pixels.
		/// </summary>
		/// <see cref="Face"/>
		public int Descender
		{
			get
			{
				return Marshal.ReadInt32(reference + 16);
			}
		}

		/// <summary>
		/// The height in 26.6 fractional pixels.
		/// </summary>
		/// <see cref="Face"/>
		public int Height
		{
			get
			{
				return Marshal.ReadInt32(reference + 20);
			}
		}

		/// <summary>
		/// The maximal advance width in 26.6 fractional pixels.
		/// </summary>
		/// <see cref="Face"/>
		public int MaxAdvance
		{
			get
			{
				return Marshal.ReadInt32(reference + 24);
			}
		}
	}
}
