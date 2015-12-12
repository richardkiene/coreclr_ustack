## coreclr app to aid in creating a ustack helper

### Running
```
// In terminal 1 (uncomment the writeline in Program.cs if you want the coreclr stack)

# dnu restore
# dnx coreclr_ustack
```
```
// In terminal 2

# gcore `pgrep dnx`
# mdb <core file name>
```

### CoreCLR System.Environment.StackTrace
```
coreclr_ustack.Program.Main(String[] args)
System.RuntimeMethodHandle.InvokeMethod(Object target, Object[] arguments, Signature sig, Boolean constructor)
System.Reflection.RuntimeMethodInfo.UnsafeInvokeInternal(Object obj, Object[] parameters, Object[] arguments)
System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)
Microsoft.Dnx.Runtime.Common.EntryPointExecutor.Execute(Assembly assembly, String[] args, IServiceProvider serviceProvider)
Microsoft.Dnx.ApplicationHost.Program.<>c__DisplayClass3_0.<ExecuteMain>b__0()
System.Threading.Tasks.Task`1.InnerInvoke()
System.Threading.Tasks.Task.Execute()
System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state)
System.Threading.Tasks.Task.ExecuteWithThreadLocal(Task& currentTaskSlot)
System.Threading.Tasks.Task.ExecuteEntry(Boolean bPreventDoubleExecution)
System.Threading.ThreadPoolWorkQueue.Dispatch()
```

### mdb ::stacks

```
> ::stacks -i
mdb: couldn't read frame for thread 0x1 at ffffffff: no mapping for address
mdb: couldn't read frame for thread 0x7 at ffffffff: no mapping for address
mdb: couldn't read frame for thread 0x8 at ffffffff: no mapping for address
THREAD           STATE    SOBJ                COUNT
1                UNPARKED <NONE>                  6

4                UNPARKED <NONE>                  1
                 LMfd`libc.so.1`poll+0x56
                 LMfd`lx_brand.so.1`lx_poll+0x163
                 LMfd`lx_brand.so.1`lx_emulate+0xbf

9                UNPARKED <NONE>                  1
                 libcoreclr.so`CallDescrWorkerInternal+0x7c
                 libcoreclr.so`_Z32CallDescrWorkerReflectionWrapperP13CallDescrDataP5Frame+0x66
                 libcoreclr.so`_ZN19RuntimeMethodHandle12InvokeMethodEP6ObjectP8PtrArrayP15SignatureNativeb+0xe3c
                 0x7ffffc6d2e16
                 0x7ffffc6d1289
                 0x7fffd799a539
                 0x7fffd799a263
                 0x7ffffa783533
                 0x7ffffa775579
                 0x7ffffa7752fa
                 0x7ffffa774fec
                 0x7ffffa774cc6
                 0x7ffffa776ae5
                 libcoreclr.so`CallDescrWorkerInternal+0x7c
                 libcoreclr.so`_ZN18MethodDescCallSite16CallTargetWorkerEPKm+0x30f
                 libcoreclr.so`_Z32QueueUserWorkItemManagedCallbackPv+0xad
                 libcoreclr.so`_ZL31ManagedThreadBase_DispatchOuterP22ManagedThreadCallState+0x19b
                 libcoreclr.so`_ZN17ManagedThreadBase10ThreadPoolE4ADIDPFvPvES1_+0x39
                 libcoreclr.so`_ZN26ManagedPerAppDomainTPCount16DispatchWorkItemEPbS0_+0x118
                 libcoreclr.so`_ZN13ThreadpoolMgr17WorkerThreadStartEPv+0x4cc
                 libcoreclr.so`_ZN7CorUnix10CPalThread11ThreadEntryEPv+0x14a

6                UNPARKED <NONE>                  1
                 libcoreclr.so`_ZN19DbgTransportSession15TransportWorkerEv+0x7b
                 libcoreclr.so`_ZN19DbgTransportSession21TransportWorkerStaticEPv+9
                 libcoreclr.so`_ZN7CorUnix10CPalThread11ThreadEntryEPv+0x14a
```
