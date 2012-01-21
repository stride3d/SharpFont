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
	/// A structure used to model a size request.
	/// </summary>
	/// <remarks>
	/// If <see cref="Width"/> is zero, then the horizontal scaling value is set equal to the vertical scaling value, and vice versa.
	/// </remarks>
	[StructLayout(LayoutKind.Sequential)]
	public sealed class SizeRequest
	{
		internal IntPtr reference;

		public SizeRequest(IntPtr reference)
		{
			this.reference = reference;
		}

		/// <summary>
		/// See <see cref="SizeRequestType"/>.
		/// </summary>
		SizeRequestType RequestType
		{
			get
			{
				return (SizeRequestType)Marshal.ReadInt32(reference + 0);
			}
		}

		/// <summary>
		/// The desired width.
		/// </summary>
		public int Width
		{
			get
			{
				return Marshal.ReadInt32(reference + 4);
			}
		}

		/// <summary>
		/// The desired height.
		/// </summary>
		public int Height
		{
			get
			{
				return Marshal.ReadInt32(reference + 8);
			}
		}

		/// <summary>
		/// The horizontal resolution. If set to zero, <see cref="Width"/> is treated as a 26.6 fractional pixel value.
		/// </summary>
		public uint HorizontalResolution
		{
			get
			{
				return (uint)Marshal.ReadInt32(reference + 12);
			}
		}

		/// <summary>
		/// The horizontal resolution. If set to zero, <see cref="Height"/> is treated as a 26.6 fractional pixel value.
		/// </summary>
		public uint VerticalResolution
		{
			get
			{
				return (uint)Marshal.ReadInt32(reference + 16);
			}
		}
	}
}
