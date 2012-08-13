﻿#region MIT License
/*Copyright (c) 2012 Robert Rouhani <robert.rouhani@gmail.com>

SharpFont based on Tao.FreeType, Copyright (c) 2003-2007 Tao Framework Team

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

using SharpFont.Internal;

namespace SharpFont
{
	/// <summary>
	/// A function used to initialize (not create) a new module object.
	/// </summary>
	/// <param name="module">The module to initialize.</param>
	/// <returns>FreeType error code.</returns>
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate Error ModuleConstructor([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ModuleMarshaler))] Module module);

	/// <summary>
	/// A function used to finalize (not destroy) a given module object.
	/// </summary>
	/// <param name="module">The module to finalize.</param>
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void ModuleDestructor([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ModuleMarshaler))] Module module);

	/// <summary>
	/// A function used to query a given module for a specific interface.
	/// </summary>
	/// <param name="module">The module that contains the interface.</param>
	/// <param name="name">The name of the interface in the module.</param>
	/// <returns>The interface.</returns>
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate IntPtr ModuleRequester([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ModuleMarshaler))] Module module, [MarshalAs(UnmanagedType.LPStr)] string name);

	/// <summary>
	/// The module class descriptor.
	/// </summary>
	public class ModuleClass
	{
		#region Fields

		private IntPtr reference;
		private ModuleClassRec rec;

		#endregion

		#region Constructors

		internal ModuleClass(IntPtr reference)
		{
			Reference = reference;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Bit flags describing the module.
		/// </summary>
		[CLSCompliant(false)]
		public uint Flags
		{
			get
			{
				return rec.module_flags;
			}
		}

		/// <summary>
		/// The size of one module object/instance in bytes.
		/// </summary>
		public int Size
		{
			get
			{
				return (int)rec.module_size;
			}
		}

		/// <summary>
		/// The name of the module.
		/// </summary>
		public string Name
		{
			get
			{
				return rec.module_name;
			}
		}

		/// <summary>
		/// The version, as a 16.16 fixed number (major.minor).
		/// </summary>
		public int Version
		{
			get
			{
				return (int)rec.module_version;
			}
		}

		/// <summary>
		/// The version of FreeType this module requires, as a 16.16 fixed number (major.minor). Starts at version 2.0,
		/// i.e., 0x20000.
		/// </summary>
		public int Requires
		{
			get
			{
				return (int)rec.module_requires;
			}
		}

		public IntPtr Interface
		{
			get
			{
				return rec.module_interface;
			}
		}

		/// <summary>
		/// The initializing function.
		/// </summary>
		public ModuleConstructor Init
		{
			get
			{
				return rec.module_init;
			}
		}

		/// <summary>
		/// The finalizing function.
		/// </summary>
		public ModuleDestructor Done
		{
			get
			{
				return rec.module_done;
			}
		}

		/// <summary>
		/// The interface requesting function.
		/// </summary>
		public ModuleRequester GetInterface
		{
			get
			{
				return rec.get_interface;
			}
		}

		internal IntPtr Reference
		{
			get
			{
				return reference;
			}

			set
			{
				reference = value;
				rec = PInvokeHelper.PtrToStructure<ModuleClassRec>(reference);
			}
		}

		#endregion
	}
}