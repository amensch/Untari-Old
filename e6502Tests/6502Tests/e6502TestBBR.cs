﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Untari.CPU;

namespace UntariTests
{
    [TestClass]
    public class e6502TestBBR
    {
        [TestMethod]
        public void TestBBR0()
        {
            TestRAM ram = new TestRAM();
            e6502 cpu = new e6502(e6502Type.CMOS, ram);
            cpu.LoadProgram(0x00, new byte[] { 0xa9, 0x55,            // LDA #$55
                                               0x85, 0x00,            // STA $00
                                               0x0f, 0x00, 0x11 });   // BBR0 $00, $11

            cpu.FetchInstruction();
            cpu.ExecuteInstruction();
            cpu.FetchInstruction();
            cpu.ExecuteInstruction();
            cpu.FetchInstruction();
            cpu.ExecuteInstruction();

            Assert.AreEqual(0x07, cpu.PC, "BBR0 failed");
        }

        [TestMethod]
        public void TestBBR1()
        {
            TestRAM ram = new TestRAM();
            e6502 cpu = new e6502(e6502Type.CMOS, ram);
            cpu.LoadProgram(0x00, new byte[] { 0xa9, 0x55,            // LDA #$55
                                               0x85, 0x00,            // STA $00
                                               0x1f, 0x00, 0x11 });   // BBR1 $00, $11

            cpu.FetchInstruction();
            cpu.ExecuteInstruction();
            cpu.FetchInstruction();
            cpu.ExecuteInstruction();
            cpu.FetchInstruction();
            cpu.ExecuteInstruction();

            Assert.AreEqual(0x18, cpu.PC, "BBR1 failed");
        }

        [TestMethod]
        public void TestBBR2()
        {
            TestRAM ram = new TestRAM();
            e6502 cpu = new e6502(e6502Type.CMOS, ram);
            cpu.LoadProgram(0x00, new byte[] { 0xa9, 0x55,            // LDA #$55
                                               0x85, 0x00,            // STA $00
                                               0x2f, 0x00, 0x11 });   // BBR2 $00, $11

            cpu.FetchInstruction();
            cpu.ExecuteInstruction();
            cpu.FetchInstruction();
            cpu.ExecuteInstruction();
            cpu.FetchInstruction();
            cpu.ExecuteInstruction();

            Assert.AreEqual(0x07, cpu.PC, "BBR2 failed");
        }

        [TestMethod]
        public void TestBBR3()
        {
            TestRAM ram = new TestRAM();
            e6502 cpu = new e6502(e6502Type.CMOS, ram);
            cpu.LoadProgram(0x00, new byte[] { 0xa9, 0x55,            // LDA #$55
                                               0x85, 0x00,            // STA $00
                                               0x3f, 0x00, 0x11 });   // BBR3 $00, $11

            cpu.FetchInstruction();
            cpu.ExecuteInstruction();
            cpu.FetchInstruction();
            cpu.ExecuteInstruction();
            cpu.FetchInstruction();
            cpu.ExecuteInstruction();

            Assert.AreEqual(0x18, cpu.PC, "BBR3 failed");
        }

        [TestMethod]
        public void TestBBR4()
        {
            TestRAM ram = new TestRAM();
            e6502 cpu = new e6502(e6502Type.CMOS, ram);
            cpu.LoadProgram(0x00, new byte[] { 0xa9, 0x55,            // LDA #$55
                                               0x85, 0x00,            // STA $00
                                               0x4f, 0x00, 0x11 });   // BBR4 $00, $11

            cpu.FetchInstruction();
            cpu.ExecuteInstruction();
            cpu.FetchInstruction();
            cpu.ExecuteInstruction();
            cpu.FetchInstruction();
            cpu.ExecuteInstruction();

            Assert.AreEqual(0x07, cpu.PC, "BBR4 failed");
        }

        [TestMethod]
        public void TestBBR5()
        {
            TestRAM ram = new TestRAM();
            e6502 cpu = new e6502(e6502Type.CMOS, ram);
            cpu.LoadProgram(0x00, new byte[] { 0xa9, 0x55,            // LDA #$55
                                               0x85, 0x00,            // STA $00
                                               0x5f, 0x00, 0x11 });   // BBR5 $00, $11

            cpu.FetchInstruction();
            cpu.ExecuteInstruction();
            cpu.FetchInstruction();
            cpu.ExecuteInstruction();
            cpu.FetchInstruction();
            cpu.ExecuteInstruction();

            Assert.AreEqual(0x18, cpu.PC, "BBR5 failed");
        }

        [TestMethod]
        public void TestBBR6()
        {
            TestRAM ram = new TestRAM();
            e6502 cpu = new e6502(e6502Type.CMOS, ram);
            cpu.LoadProgram(0x00, new byte[] { 0xa9, 0x55,            // LDA #$55
                                               0x85, 0x00,            // STA $00
                                               0x6f, 0x00, 0x11 });   // BBR6 $00, $11

            cpu.FetchInstruction();
            cpu.ExecuteInstruction();
            cpu.FetchInstruction();
            cpu.ExecuteInstruction();
            cpu.FetchInstruction();
            cpu.ExecuteInstruction();

            Assert.AreEqual(0x07, cpu.PC, "BBR6 failed");
        }

        [TestMethod]
        public void TestBBR7()
        {
            TestRAM ram = new TestRAM();
            e6502 cpu = new e6502(e6502Type.CMOS, ram);
            cpu.LoadProgram(0x00, new byte[] { 0xa9, 0x55,            // LDA #$55
                                               0x85, 0x00,            // STA $00
                                               0x7f, 0x00, 0x11 });   // BBR7 $00, $11

            cpu.FetchInstruction();
            cpu.ExecuteInstruction();
            cpu.FetchInstruction();
            cpu.ExecuteInstruction();
            cpu.FetchInstruction();
            cpu.ExecuteInstruction();

            Assert.AreEqual(0x18, cpu.PC, "BBR7 failed");
        }
    }
}
