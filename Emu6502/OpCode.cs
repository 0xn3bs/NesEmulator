using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emu6502
{
    class OpCode
    {
        public enum AddressingMode
        {
            Accumulator,    //  A		....	Accumulator             OPC A       operand is AC
            Implied,        //  impl    ....	implied	 	            OPC	 	    operand implied
            Immediate,      //  #		....	immediate	 	        OPC #$BB	operand is byte (BB)
            ZeroPage,       //  zpg		....	zeropage	 	        OPC $LL	 	operand is of address; address hibyte = zero ($00xx)
            ZeroPageX,      //  zpg,X   ....	zeropage, X-indexed	 	OPC $LL,X   operand is address incremented by X; address hibyte = zero ($00xx); no page transition
            ZeroPageY,      //  zpg,Y	....	zeropage, Y-indexed	 	OPC $LL,Y	operand is address incremented by Y; address hibyte = zero ($00xx); no page transition
            Absolute,       //  abs		....	absolute	 	        OPC $HHLL   operand is address $HHLL
            AbsoluteX,      //  abs,X	....	absolute, X-indexed	 	OPC $HHLL,X operand is address incremented by X with carry
            AbsoluteY,      //  abs,Y   ....	absolute, Y-indexed	 	OPC $HHLL,Y operand is address incremented by Y with carry
            IndirectX,      //  X,ind	....	X-indexed, indirect	    OPC ($BB,X)	operand is effective zeropage address; effective address is byte (BB) incremented by X without carry
            IndirectY       //  ind,Y	....	indirect, Y-indexed	 	OPC ($LL),Y	operand is effective address incremented by Y with carry; effective address is word at zeropage address
        }

        public static Dictionary<string, Dictionary<AddressingMode, byte>> opcodes = new Dictionary<string, Dictionary<AddressingMode, byte>>()
        {
            //  ADC
            {"ADC", new Dictionary<AddressingMode, byte> {{AddressingMode.Immediate,    0x69}}},
            {"ADC", new Dictionary<AddressingMode, byte> {{AddressingMode.ZeroPage,     0x65}}},
            {"ADC", new Dictionary<AddressingMode, byte> {{AddressingMode.ZeroPageX,    0x75}}},
            {"ADC", new Dictionary<AddressingMode, byte> {{AddressingMode.Absolute,     0x6D}}},
            {"ADC", new Dictionary<AddressingMode, byte> {{AddressingMode.AbsoluteX,    0x7D}}},
            {"ADC", new Dictionary<AddressingMode, byte> {{AddressingMode.AbsoluteY,    0x79}}},
            {"ADC", new Dictionary<AddressingMode, byte> {{AddressingMode.IndirectX,    0x61}}},
            {"ADC", new Dictionary<AddressingMode, byte> {{AddressingMode.IndirectY,    0x71}}},

            //  AND
            {"AND", new Dictionary<AddressingMode, byte> {{AddressingMode.Immediate,    0x29}}},
            {"AND", new Dictionary<AddressingMode, byte> {{AddressingMode.ZeroPage,     0x25}}},
            {"AND", new Dictionary<AddressingMode, byte> {{AddressingMode.ZeroPageX,    0x35}}},
            {"AND", new Dictionary<AddressingMode, byte> {{AddressingMode.Absolute,     0x2D}}},
            {"AND", new Dictionary<AddressingMode, byte> {{AddressingMode.AbsoluteX,    0x3D}}},
            {"AND", new Dictionary<AddressingMode, byte> {{AddressingMode.AbsoluteY,    0x39}}},
            {"AND", new Dictionary<AddressingMode, byte> {{AddressingMode.IndirectX,    0x21}}},
            {"AND", new Dictionary<AddressingMode, byte> {{AddressingMode.IndirectY,    0x31}}},

            //  ASL
            {"ASL", new Dictionary<AddressingMode, byte> {{AddressingMode.Accumulator,  0x0A}}},
            {"ASL", new Dictionary<AddressingMode, byte> {{AddressingMode.ZeroPage,     0x06}}},
            {"ASL", new Dictionary<AddressingMode, byte> {{AddressingMode.ZeroPageX,    0x16}}},
            {"ASL", new Dictionary<AddressingMode, byte> {{AddressingMode.Absolute,     0x0E}}},
            {"ASL", new Dictionary<AddressingMode, byte> {{AddressingMode.AbsoluteX,    0x1E}}},

            {"BCC", new Dictionary<AddressingMode, byte> {{AddressingMode.Implied,      0x90}}},

            {"BCS", new Dictionary<AddressingMode, byte> {{AddressingMode.Implied,      0xB0}}},

            {"BEQ", new Dictionary<AddressingMode, byte> {{AddressingMode.Implied,      0xF0}}},

            //  BIT
            {"BIT", new Dictionary<AddressingMode, byte> {{AddressingMode.ZeroPage,     0x24}}},
            {"BIT", new Dictionary<AddressingMode, byte> {{AddressingMode.Absolute,     0x2C}}},

            {"BMI", new Dictionary<AddressingMode, byte> {{AddressingMode.Implied,      0x30}}},


            {"BNE", new Dictionary<AddressingMode, byte> {{AddressingMode.Implied,      0xD0}}},

            {"BPL", new Dictionary<AddressingMode, byte> {{AddressingMode.Implied,      0x10}}},

            {"BRK", new Dictionary<AddressingMode, byte> {{AddressingMode.Implied,      0x00}}},

            {"BVC", new Dictionary<AddressingMode, byte> {{AddressingMode.Implied,      0x50}}},

            {"BVS", new Dictionary<AddressingMode, byte> {{AddressingMode.Implied,      0x70}}},

            {"CLC", new Dictionary<AddressingMode, byte> {{AddressingMode.Implied,      0x18}}},

            {"CLD", new Dictionary<AddressingMode, byte> {{AddressingMode.Implied,      0xD8}}},

            {"CLI", new Dictionary<AddressingMode, byte> {{AddressingMode.Implied,      0x58}}},

            {"CLV", new Dictionary<AddressingMode, byte> {{AddressingMode.Implied,      0xB8}}},

            //  CMP
            {"CMP", new Dictionary<AddressingMode, byte> {{AddressingMode.Immediate,    0xC9}}},
            {"CMP", new Dictionary<AddressingMode, byte> {{AddressingMode.ZeroPage,     0xC5}}},
            {"CMP", new Dictionary<AddressingMode, byte> {{AddressingMode.ZeroPageX,    0xD5}}},
            {"CMP", new Dictionary<AddressingMode, byte> {{AddressingMode.Absolute,     0xCD}}},
            {"CMP", new Dictionary<AddressingMode, byte> {{AddressingMode.AbsoluteX,    0xDD}}},
            {"CMP", new Dictionary<AddressingMode, byte> {{AddressingMode.AbsoluteY,    0xD9}}},
            {"CMP", new Dictionary<AddressingMode, byte> {{AddressingMode.IndirectX,    0xC1}}},
            {"CMP", new Dictionary<AddressingMode, byte> {{AddressingMode.IndirectY,    0xD1}}},

            //  CPX
            {"CPX", new Dictionary<AddressingMode, byte> {{AddressingMode.Immediate,    0xE0}}},
            {"CPX", new Dictionary<AddressingMode, byte> {{AddressingMode.ZeroPage,     0xE4}}},
            {"CPX", new Dictionary<AddressingMode, byte> {{AddressingMode.Absolute,     0xEC}}},

            //  CPY
            {"CPX", new Dictionary<AddressingMode, byte> {{AddressingMode.Immediate,    0xC0}}},
            {"CPX", new Dictionary<AddressingMode, byte> {{AddressingMode.ZeroPage,     0xC4}}},
            {"CPX", new Dictionary<AddressingMode, byte> {{AddressingMode.Absolute,     0xCC}}},

            //  DEC
            {"DEC", new Dictionary<AddressingMode, byte> {{AddressingMode.ZeroPage,     0xC6}}},
            {"DEC", new Dictionary<AddressingMode, byte> {{AddressingMode.ZeroPageX,    0xD6}}},
            {"DEC", new Dictionary<AddressingMode, byte> {{AddressingMode.Absolute,     0xCE}}},
            {"DEC", new Dictionary<AddressingMode, byte> {{AddressingMode.AbsoluteX,    0xDE}}}
        };
    }
}
