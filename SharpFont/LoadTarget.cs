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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpFont
{
	/// <summary>
	/// A list of values that are used to select a specific hinting algorithm
	/// to use by the hinter. You should OR one of these values to your
	/// ‘load_flags’ when calling FT_Load_Glyph.
	/// 
	/// Note that font's native hinters may ignore the hinting algorithm you 
	/// have specified (e.g., the TrueType bytecode interpreter). You can set
	/// FT_LOAD_FORCE_AUTOHINT to ensure that the auto-hinter is used.
	/// 
	/// Also note that FT_LOAD_TARGET_LIGHT is an exception, in that it always
	/// implies FT_LOAD_FORCE_AUTOHINT.
	/// </summary>
	/// <remarks>
	/// You should use only one of the FT_LOAD_TARGET_XXX values in your 
	/// ‘load_flags’. They can't be ORed.
	/// 
	/// If FT_LOAD_RENDER is also set, the glyph is rendered in the
	/// corresponding mode (i.e., the mode which matches the used algorithm
	/// best) unless FT_LOAD_MONOCHROME is set.
	/// 
	/// You can use a hinting algorithm that doesn't correspond to the same 
	/// rendering mode. As an example, it is possible to use the ‘light’ 
	/// hinting algorithm and have the results rendered in horizontal LCD pixel
	/// mode, with code like:
	/// <code>
	/// FT_Load_Glyph( face, glyph_index,
	///          load_flags | FT_LOAD_TARGET_LIGHT );
	///
	/// FT_Render_Glyph( face->glyph, FT_RENDER_MODE_LCD );
	/// </code>
	/// </remarks>
	public enum LoadTarget
	{
		/// <summary>
		/// This corresponds to the default hinting algorithm, optimized for 
		/// standard gray-level rendering. For monochrome output, use 
		/// FT_LOAD_TARGET_MONO instead.
		/// </summary>
		Normal =		(RenderMode.Normal & 15) << 16,

		/// <summary>
		/// A lighter hinting algorithm for non-monochrome modes. Many
		/// generated glyphs are more fuzzy but better resemble its original 
		/// shape. A bit like rendering on Mac OS X.
		/// 
		/// As a special exception, this target implies FT_LOAD_FORCE_AUTOHINT.
		/// </summary>
		Light =			(RenderMode.Light & 15) << 16,

		/// <summary>
		/// Strong hinting algorithm that should only be used for monochrome
		/// output. The result is probably unpleasant if the glyph is rendered
		/// in non-monochrome modes.
		/// </summary>
		Mono =			(RenderMode.Mono & 15) << 16,

		/// <summary>
		/// A variant of FT_LOAD_TARGET_NORMAL optimized for horizontally 
		/// decimated LCD displays.
		/// </summary>
		LCD =			(RenderMode.LCD & 15) << 16,

		/// <summary>
		/// A variant of FT_LOAD_TARGET_NORMAL optimized for vertically 
		/// decimated LCD displays.
		/// </summary>
		VerticalLCD =	(RenderMode.VerticalLCD & 15) << 16
	}
}
