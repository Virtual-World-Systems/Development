
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.8.3928.0
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern netstandard
{
  .publickeytoken = (CC 7B 13 FF CD 2D DD 51 )                         // .{...-.Q
  .ver 2:0:0:0
}
.assembly ClassLibrary1
{
  .custom instance void [netstandard]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [netstandard]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                                63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [netstandard]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [netstandard]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .custom instance void [netstandard]System.Runtime.Versioning.TargetFrameworkAttribute::.ctor(string) = ( 01 00 19 2E 4E 45 54 53 74 61 6E 64 61 72 64 2C   // ....NETStandard,
                                                                                                           56 65 72 73 69 6F 6E 3D 76 32 2E 30 01 00 54 0E   // Version=v2.0..T.
                                                                                                           14 46 72 61 6D 65 77 6F 72 6B 44 69 73 70 6C 61   // .FrameworkDispla
                                                                                                           79 4E 61 6D 65 11 2E 4E 45 54 20 53 74 61 6E 64   // yName..NET Stand
                                                                                                           61 72 64 20 32 2E 30 )                            // ard 2.0
  .custom instance void [netstandard]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 0D 43 6C 61 73 73 4C 69 62 72 61 72 79 31   // ...ClassLibrary1
                                                                                                   00 00 ) 
  .custom instance void [netstandard]System.Reflection.AssemblyConfigurationAttribute::.ctor(string) = ( 01 00 05 44 65 62 75 67 00 00 )                   // ...Debug..
  .custom instance void [netstandard]System.Reflection.AssemblyFileVersionAttribute::.ctor(string) = ( 01 00 07 31 2E 30 2E 30 2E 30 00 00 )             // ...1.0.0.0..
  .custom instance void [netstandard]System.Reflection.AssemblyInformationalVersionAttribute::.ctor(string) = ( 01 00 05 31 2E 30 2E 30 00 00 )                   // ...1.0.0..
  .custom instance void [netstandard]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 0D 43 6C 61 73 73 4C 69 62 72 61 72 79 31   // ...ClassLibrary1
                                                                                                   00 00 ) 
  .custom instance void [netstandard]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 0D 43 6C 61 73 73 4C 69 62 72 61 72 79 31   // ...ClassLibrary1
                                                                                                 00 00 ) 
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.module ClassLibrary1.dll
// MVID: {B2C5A286-B164-4888-9AEE-97E1B4B38777}
.imagebase 0x10000000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x005D0000


// =============== CLASS MEMBERS DECLARATION ===================

.class public auto ansi beforefieldinit ClassLibrary1.Class1
       extends [netstandard]System.Object
{
  .class auto ansi sealed nested private beforefieldinit '<get_TestString2>d__3'
         extends [netstandard]System.Object
         implements class [netstandard]System.Collections.Generic.IEnumerator`1<object>,
                    [netstandard]System.Collections.IEnumerator,
                    [netstandard]System.IDisposable
  {
    .custom instance void [netstandard]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    .field private int32 '<>1__state'
    .field private object '<>2__current'
    .method public hidebysig specialname rtspecialname 
            instance void  .ctor(int32 '<>1__state') cil managed
    {
      .custom instance void [netstandard]System.Diagnostics.DebuggerHiddenAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       15 (0xf)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  call       instance void [netstandard]System.Object::.ctor()
      IL_0006:  nop
      IL_0007:  ldarg.0
      IL_0008:  ldarg.1
      IL_0009:  stfld      int32 ClassLibrary1.Class1/'<get_TestString2>d__3'::'<>1__state'
      IL_000e:  ret
    } // end of method '<get_TestString2>d__3'::.ctor

    .method private hidebysig newslot virtual final 
            instance void  System.IDisposable.Dispose() cil managed
    {
      .custom instance void [netstandard]System.Diagnostics.DebuggerHiddenAttribute::.ctor() = ( 01 00 00 00 ) 
      .override [netstandard]System.IDisposable::Dispose
      // Code size       1 (0x1)
      .maxstack  8
      IL_0000:  ret
    } // end of method '<get_TestString2>d__3'::System.IDisposable.Dispose

    .method private hidebysig newslot virtual final 
            instance bool  MoveNext() cil managed
    {
      .override [netstandard]System.Collections.IEnumerator::MoveNext
      // Code size       61 (0x3d)
      .maxstack  2
      .locals init (int32 V_0)
      IL_0000:  ldarg.0
      IL_0001:  ldfld      int32 ClassLibrary1.Class1/'<get_TestString2>d__3'::'<>1__state'
      IL_0006:  stloc.0
      IL_0007:  ldloc.0
      IL_0008:  brfalse.s  IL_0012

      IL_000a:  br.s       IL_000c

      IL_000c:  ldloc.0
      IL_000d:  ldc.i4.1
      IL_000e:  beq.s      IL_0014

      IL_0010:  br.s       IL_0016

      IL_0012:  br.s       IL_0018

      IL_0014:  br.s       IL_0034

      IL_0016:  ldc.i4.0
      IL_0017:  ret

      IL_0018:  ldarg.0
      IL_0019:  ldc.i4.m1
      IL_001a:  stfld      int32 ClassLibrary1.Class1/'<get_TestString2>d__3'::'<>1__state'
      IL_001f:  nop
      IL_0020:  ldarg.0
      IL_0021:  ldstr      "TestString"
      IL_0026:  stfld      object ClassLibrary1.Class1/'<get_TestString2>d__3'::'<>2__current'
      IL_002b:  ldarg.0
      IL_002c:  ldc.i4.1
      IL_002d:  stfld      int32 ClassLibrary1.Class1/'<get_TestString2>d__3'::'<>1__state'
      IL_0032:  ldc.i4.1
      IL_0033:  ret

      IL_0034:  ldarg.0
      IL_0035:  ldc.i4.m1
      IL_0036:  stfld      int32 ClassLibrary1.Class1/'<get_TestString2>d__3'::'<>1__state'
      IL_003b:  ldc.i4.0
      IL_003c:  ret
    } // end of method '<get_TestString2>d__3'::MoveNext

    .method private hidebysig newslot specialname virtual final 
            instance object  'System.Collections.Generic.IEnumerator<System.Object>.get_Current'() cil managed
    {
      .custom instance void [netstandard]System.Diagnostics.DebuggerHiddenAttribute::.ctor() = ( 01 00 00 00 ) 
      .override  method instance !0 class [netstandard]System.Collections.Generic.IEnumerator`1<object>::get_Current()
      // Code size       7 (0x7)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  ldfld      object ClassLibrary1.Class1/'<get_TestString2>d__3'::'<>2__current'
      IL_0006:  ret
    } // end of method '<get_TestString2>d__3'::'System.Collections.Generic.IEnumerator<System.Object>.get_Current'

    .method private hidebysig newslot virtual final 
            instance void  System.Collections.IEnumerator.Reset() cil managed
    {
      .custom instance void [netstandard]System.Diagnostics.DebuggerHiddenAttribute::.ctor() = ( 01 00 00 00 ) 
      .override [netstandard]System.Collections.IEnumerator::Reset
      // Code size       6 (0x6)
      .maxstack  8
      IL_0000:  newobj     instance void [netstandard]System.NotSupportedException::.ctor()
      IL_0005:  throw
    } // end of method '<get_TestString2>d__3'::System.Collections.IEnumerator.Reset

    .method private hidebysig newslot specialname virtual final 
            instance object  System.Collections.IEnumerator.get_Current() cil managed
    {
      .custom instance void [netstandard]System.Diagnostics.DebuggerHiddenAttribute::.ctor() = ( 01 00 00 00 ) 
      .override [netstandard]System.Collections.IEnumerator::get_Current
      // Code size       7 (0x7)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  ldfld      object ClassLibrary1.Class1/'<get_TestString2>d__3'::'<>2__current'
      IL_0006:  ret
    } // end of method '<get_TestString2>d__3'::System.Collections.IEnumerator.get_Current

    .property instance object 'System.Collections.Generic.IEnumerator<System.Object>.Current'()
    {
      .get instance object ClassLibrary1.Class1/'<get_TestString2>d__3'::'System.Collections.Generic.IEnumerator<System.Object>.get_Current'()
    } // end of property '<get_TestString2>d__3'::'System.Collections.Generic.IEnumerator<System.Object>.Current'
    .property instance object System.Collections.IEnumerator.Current()
    {
      .get instance object ClassLibrary1.Class1/'<get_TestString2>d__3'::System.Collections.IEnumerator.get_Current()
    } // end of property '<get_TestString2>d__3'::System.Collections.IEnumerator.Current
  } // end of class '<get_TestString2>d__3'

  .method public hidebysig specialname static 
          string  get_TestString() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  1
    .locals init (string V_0)
    IL_0000:  nop
    IL_0001:  ldstr      "TestString"
    IL_0006:  stloc.0
    IL_0007:  br.s       IL_0009

    IL_0009:  ldloc.0
    IL_000a:  ret
  } // end of method Class1::get_TestString

  .method public hidebysig specialname static 
          class [netstandard]System.Collections.IEnumerator 
          get_TestString2() cil managed
  {
    .custom instance void [netstandard]System.Runtime.CompilerServices.IteratorStateMachineAttribute::.ctor(class [netstandard]System.Type) = ( 01 00 2A 43 6C 61 73 73 4C 69 62 72 61 72 79 31   // ..*ClassLibrary1
                                                                                                                                                2E 43 6C 61 73 73 31 2B 3C 67 65 74 5F 54 65 73   // .Class1+<get_Tes
                                                                                                                                                74 53 74 72 69 6E 67 32 3E 64 5F 5F 33 00 00 )    // tString2>d__3..
    // Code size       11 (0xb)
    .maxstack  1
    .locals init (class ClassLibrary1.Class1/'<get_TestString2>d__3' V_0,
             class [netstandard]System.Collections.IEnumerator V_1)
    IL_0000:  ldc.i4.0
    IL_0001:  newobj     instance void ClassLibrary1.Class1/'<get_TestString2>d__3'::.ctor(int32)
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  stloc.1
    IL_0009:  ldloc.1
    IL_000a:  ret
  } // end of method Class1::get_TestString2

  .method public hidebysig static valuetype [netstandard]System.ValueTuple`2<int32,char> 
          xyz(string x) cil managed
  {
    // Code size       14 (0xe)
    .maxstack  2
    .locals init (valuetype [netstandard]System.ValueTuple`2<int32,char> V_0)
    IL_0000:  nop
    IL_0001:  ldc.i4.2
    IL_0002:  ldc.i4.s   115
    IL_0004:  newobj     instance void valuetype [netstandard]System.ValueTuple`2<int32,char>::.ctor(!0,
                                                                                                     !1)
    IL_0009:  stloc.0
    IL_000a:  br.s       IL_000c

    IL_000c:  ldloc.0
    IL_000d:  ret
  } // end of method Class1::xyz

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [netstandard]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method Class1::.ctor

  .property string TestString()
  {
    .get string ClassLibrary1.Class1::get_TestString()
  } // end of property Class1::TestString
  .property class [netstandard]System.Collections.IEnumerator
          TestString2()
  {
    .get class [netstandard]System.Collections.IEnumerator ClassLibrary1.Class1::get_TestString2()
  } // end of property Class1::TestString2
} // end of class ClassLibrary1.Class1


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file C:\github\Virtual-World-Systems\Development\Collaborator\OwlEyes\Solution(s)\OpenSimulator\ClassLibrary1\bin\Debug\netstandard2.0\b.res
