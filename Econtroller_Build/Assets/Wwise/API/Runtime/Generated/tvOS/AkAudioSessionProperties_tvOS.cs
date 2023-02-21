#if UNITY_TVOS && ! UNITY_EDITOR
//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 4.0.2
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class AkAudioSessionProperties : global::System.IDisposable {
  private global::System.IntPtr swigCPtr;
  protected bool swigCMemOwn;

  internal AkAudioSessionProperties(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = cPtr;
  }

  internal static global::System.IntPtr getCPtr(AkAudioSessionProperties obj) {
    return (obj == null) ? global::System.IntPtr.Zero : obj.swigCPtr;
  }

  internal virtual void setCPtr(global::System.IntPtr cPtr) {
    Dispose();
    swigCPtr = cPtr;
  }

  ~AkAudioSessionProperties() {
    Dispose(false);
  }

  public void Dispose() {
    Dispose(true);
    global::System.GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing) {
    lock(this) {
      if (swigCPtr != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          AkSoundEnginePINVOKE.CSharp_delete_AkAudioSessionProperties(swigCPtr);
        }
        swigCPtr = global::System.IntPtr.Zero;
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public AkAudioSessionCategory eCategory { set { AkSoundEnginePINVOKE.CSharp_AkAudioSessionProperties_eCategory_set(swigCPtr, (int)value); }  get { return (AkAudioSessionCategory)AkSoundEnginePINVOKE.CSharp_AkAudioSessionProperties_eCategory_get(swigCPtr); } 
  }

  public AkAudioSessionCategoryOptions eCategoryOptions { set { AkSoundEnginePINVOKE.CSharp_AkAudioSessionProperties_eCategoryOptions_set(swigCPtr, (int)value); }  get { return (AkAudioSessionCategoryOptions)AkSoundEnginePINVOKE.CSharp_AkAudioSessionProperties_eCategoryOptions_get(swigCPtr); } 
  }

  public AkAudioSessionMode eMode { set { AkSoundEnginePINVOKE.CSharp_AkAudioSessionProperties_eMode_set(swigCPtr, (int)value); }  get { return (AkAudioSessionMode)AkSoundEnginePINVOKE.CSharp_AkAudioSessionProperties_eMode_get(swigCPtr); } 
  }

  public AkAudioSessionSetActiveOptions eSetActivateOptions { set { AkSoundEnginePINVOKE.CSharp_AkAudioSessionProperties_eSetActivateOptions_set(swigCPtr, (int)value); }  get { return (AkAudioSessionSetActiveOptions)AkSoundEnginePINVOKE.CSharp_AkAudioSessionProperties_eSetActivateOptions_get(swigCPtr); } 
  }

  public AkAudioSessionBehaviorOptions eAudioSessionBehavior { set { AkSoundEnginePINVOKE.CSharp_AkAudioSessionProperties_eAudioSessionBehavior_set(swigCPtr, (int)value); }  get { return (AkAudioSessionBehaviorOptions)AkSoundEnginePINVOKE.CSharp_AkAudioSessionProperties_eAudioSessionBehavior_get(swigCPtr); } 
  }

  public AkAudioSessionProperties() : this(AkSoundEnginePINVOKE.CSharp_new_AkAudioSessionProperties(), true) {
  }

}
#endif // #if UNITY_TVOS && ! UNITY_EDITOR