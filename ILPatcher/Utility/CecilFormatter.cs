﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mono;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ILPatcher
{
	class CecilFormatter
	{
		private static string zeroformat = string.Empty;

		public static string TryFormat(object objref, bool tryOperandFormat = true)
		{
			if (objref == null)
				return string.Empty;
			else if (objref is VariableReference)
				return CecilFormatter.Format((VariableReference)objref);
			else if (objref is ParameterReference)
				return CecilFormatter.Format((ParameterReference)objref);
			else if (objref is Instruction)
				return CecilFormatter.Format((Instruction)objref);
			else
				return objref.ToString();
		}

		public static string Format(VariableReference varref)
		{
			StringBuilder strb = new StringBuilder();
			strb.Append("Var");
			strb.Append(varref.Index);
			if (varref.Name != string.Empty)
			{
				strb.Append(" (");
				strb.Append(varref.Name);
				strb.Append(')');
			}
			strb.Append(" : ");
			strb.Append(varref.VariableType.FullName);
			return strb.ToString();
		}

		public static string Format(ParameterReference varref)
		{
			StringBuilder strb = new StringBuilder();
			strb.Append(varref.Name);
			strb.Append(" : ");
			strb.Append(varref.ParameterType.FullName);
			return strb.ToString();
		}

		public static string Format(Instruction instr, int pos = -1)
		{
			StringBuilder strb = new StringBuilder();
			if (pos != -1)
			{
				strb.Append("# ");
				if (zeroformat == string.Empty)
					strb.Append(pos);
				else
					strb.Append(pos.ToString(zeroformat));
				strb.Append(" | ");
			}
			strb.Append(instr.OpCode.Name);
			if (instr.Operand != null)
			{
				strb.Append(" -> ");
				if (instr.Operand is Instruction)
					strb.Append(instr.Operand.ToString());
				else
					strb.Append(TryFormat(instr.Operand));
			}
			return strb.ToString();
		}

		public static void SetMaxNumer(int max)
		{
			zeroformat = 'D' + max.ToString().Length.ToString();
		}

		public static void ClearMaxNumer()
		{
			zeroformat = string.Empty;
		}
	}
}
