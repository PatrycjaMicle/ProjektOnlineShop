; ModuleID = 'obj\Debug\130\android\marshal_methods.armeabi-v7a.ll'
source_filename = "obj\Debug\130\android\marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [170 x i32] [
	i32 32687329, ; 0: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 44
	i32 34715100, ; 1: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 73
	i32 57263871, ; 2: Xamarin.Forms.Core.dll => 0x369c6ff => 68
	i32 101534019, ; 3: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 58
	i32 120558881, ; 4: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 58
	i32 165246403, ; 5: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 25
	i32 182336117, ; 6: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 59
	i32 209399409, ; 7: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 23
	i32 230216969, ; 8: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 39
	i32 232815796, ; 9: System.Web.Services => 0xde07cb4 => 83
	i32 261689757, ; 10: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 28
	i32 278686392, ; 11: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 43
	i32 280482487, ; 12: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 37
	i32 318968648, ; 13: Xamarin.AndroidX.Activity.dll => 0x13031348 => 15
	i32 321597661, ; 14: System.Numerics => 0x132b30dd => 10
	i32 334780599, ; 15: SklepInternetowy.Android => 0x13f458b7 => 0
	i32 342366114, ; 16: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 41
	i32 441335492, ; 17: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 27
	i32 442521989, ; 18: Xamarin.Essentials => 0x1a605985 => 67
	i32 450948140, ; 19: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 36
	i32 465846621, ; 20: mscorlib => 0x1bc4415d => 6
	i32 469710990, ; 21: System.dll => 0x1bff388e => 9
	i32 476646585, ; 22: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 37
	i32 486930444, ; 23: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 48
	i32 526420162, ; 24: System.Transactions.dll => 0x1f6088c2 => 78
	i32 605376203, ; 25: System.IO.Compression.FileSystem => 0x24154ecb => 81
	i32 627609679, ; 26: Xamarin.AndroidX.CustomView => 0x2568904f => 32
	i32 663517072, ; 27: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 64
	i32 666292255, ; 28: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 20
	i32 690569205, ; 29: System.Xml.Linq.dll => 0x29293ff5 => 14
	i32 775507847, ; 30: System.IO.Compression => 0x2e394f87 => 80
	i32 809851609, ; 31: System.Drawing.Common.dll => 0x30455ad9 => 75
	i32 843511501, ; 32: Xamarin.AndroidX.Print => 0x3246f6cd => 55
	i32 924368921, ; 33: SklepInternetowy.dll => 0x3718c019 => 7
	i32 928116545, ; 34: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 73
	i32 964361005, ; 35: SklepInternetowy => 0x397afb2d => 7
	i32 967690846, ; 36: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 41
	i32 974778368, ; 37: FormsViewGroup.dll => 0x3a19f000 => 3
	i32 1012816738, ; 38: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 57
	i32 1035644815, ; 39: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 19
	i32 1042160112, ; 40: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 70
	i32 1052210849, ; 41: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 45
	i32 1098259244, ; 42: System => 0x41761b2c => 9
	i32 1175144683, ; 43: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 62
	i32 1178241025, ; 44: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 52
	i32 1204270330, ; 45: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 20
	i32 1267360935, ; 46: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 63
	i32 1293217323, ; 47: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 34
	i32 1365406463, ; 48: System.ServiceModel.Internals.dll => 0x516272ff => 74
	i32 1376866003, ; 49: Xamarin.AndroidX.SavedState => 0x52114ed3 => 57
	i32 1395857551, ; 50: Xamarin.AndroidX.Media.dll => 0x5333188f => 49
	i32 1406073936, ; 51: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 29
	i32 1460219004, ; 52: Xamarin.Forms.Xaml => 0x57092c7c => 71
	i32 1462112819, ; 53: System.IO.Compression.dll => 0x57261233 => 80
	i32 1469204771, ; 54: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 18
	i32 1582372066, ; 55: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 33
	i32 1592978981, ; 56: System.Runtime.Serialization.dll => 0x5ef2ee25 => 2
	i32 1622152042, ; 57: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 47
	i32 1624863272, ; 58: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 66
	i32 1636350590, ; 59: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 31
	i32 1639515021, ; 60: System.Net.Http.dll => 0x61b9038d => 1
	i32 1657153582, ; 61: System.Runtime => 0x62c6282e => 12
	i32 1658241508, ; 62: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 60
	i32 1658251792, ; 63: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 72
	i32 1670060433, ; 64: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 28
	i32 1729485958, ; 65: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 24
	i32 1766324549, ; 66: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 59
	i32 1776026572, ; 67: System.Core.dll => 0x69dc03cc => 8
	i32 1788241197, ; 68: Xamarin.AndroidX.Fragment => 0x6a96652d => 36
	i32 1808609942, ; 69: Xamarin.AndroidX.Loader => 0x6bcd3296 => 47
	i32 1813201214, ; 70: Xamarin.Google.Android.Material => 0x6c13413e => 72
	i32 1818569960, ; 71: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 53
	i32 1867746548, ; 72: Xamarin.Essentials.dll => 0x6f538cf4 => 67
	i32 1878053835, ; 73: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 71
	i32 1885316902, ; 74: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 21
	i32 1919157823, ; 75: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 50
	i32 2019465201, ; 76: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 45
	i32 2055257422, ; 77: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 42
	i32 2079903147, ; 78: System.Runtime.dll => 0x7bf8cdab => 12
	i32 2090596640, ; 79: System.Numerics.Vectors => 0x7c9bf920 => 11
	i32 2097448633, ; 80: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 38
	i32 2126786730, ; 81: Xamarin.Forms.Platform.Android => 0x7ec430aa => 69
	i32 2201231467, ; 82: System.Net.Http => 0x8334206b => 1
	i32 2217644978, ; 83: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 62
	i32 2244775296, ; 84: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 48
	i32 2256548716, ; 85: Xamarin.AndroidX.MultiDex => 0x8680336c => 50
	i32 2261435625, ; 86: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 40
	i32 2279755925, ; 87: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 56
	i32 2315684594, ; 88: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 16
	i32 2409053734, ; 89: Xamarin.AndroidX.Preference.dll => 0x8f973e26 => 54
	i32 2465532216, ; 90: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 27
	i32 2471841756, ; 91: netstandard.dll => 0x93554fdc => 76
	i32 2475788418, ; 92: Java.Interop.dll => 0x93918882 => 4
	i32 2501346920, ; 93: System.Data.DataSetExtensions => 0x95178668 => 79
	i32 2505896520, ; 94: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 44
	i32 2581819634, ; 95: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 63
	i32 2620871830, ; 96: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 31
	i32 2624644809, ; 97: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 35
	i32 2633051222, ; 98: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 43
	i32 2701096212, ; 99: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 60
	i32 2732626843, ; 100: Xamarin.AndroidX.Activity => 0xa2e0939b => 15
	i32 2737747696, ; 101: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 18
	i32 2766581644, ; 102: Xamarin.Forms.Core => 0xa4e6af8c => 68
	i32 2778768386, ; 103: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 65
	i32 2810250172, ; 104: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 29
	i32 2819470561, ; 105: System.Xml.dll => 0xa80db4e1 => 13
	i32 2853208004, ; 106: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 65
	i32 2855708567, ; 107: Xamarin.AndroidX.Transition => 0xaa36a797 => 61
	i32 2903344695, ; 108: System.ComponentModel.Composition => 0xad0d8637 => 82
	i32 2905242038, ; 109: mscorlib.dll => 0xad2a79b6 => 6
	i32 2916838712, ; 110: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 66
	i32 2919462931, ; 111: System.Numerics.Vectors.dll => 0xae037813 => 11
	i32 2921128767, ; 112: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 17
	i32 2949586115, ; 113: SklepInternetowy.Android.dll => 0xafcf1cc3 => 0
	i32 2978675010, ; 114: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 34
	i32 3024354802, ; 115: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 39
	i32 3044182254, ; 116: FormsViewGroup => 0xb57288ee => 3
	i32 3057625584, ; 117: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 51
	i32 3111772706, ; 118: System.Runtime.Serialization => 0xb979e222 => 2
	i32 3204380047, ; 119: System.Data.dll => 0xbefef58f => 77
	i32 3211777861, ; 120: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 33
	i32 3247949154, ; 121: Mono.Security => 0xc197c562 => 84
	i32 3258312781, ; 122: Xamarin.AndroidX.CardView => 0xc235e84d => 24
	i32 3267021929, ; 123: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 22
	i32 3317135071, ; 124: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 32
	i32 3317144872, ; 125: System.Data => 0xc5b79d28 => 77
	i32 3340431453, ; 126: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 21
	i32 3346324047, ; 127: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 52
	i32 3353484488, ; 128: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 38
	i32 3362522851, ; 129: Xamarin.AndroidX.Core => 0xc86c06e3 => 30
	i32 3366347497, ; 130: Java.Interop => 0xc8a662e9 => 4
	i32 3374999561, ; 131: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 56
	i32 3404865022, ; 132: System.ServiceModel.Internals => 0xcaf21dfe => 74
	i32 3429136800, ; 133: System.Xml => 0xcc6479a0 => 13
	i32 3430777524, ; 134: netstandard => 0xcc7d82b4 => 76
	i32 3441283291, ; 135: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 35
	i32 3476120550, ; 136: Mono.Android => 0xcf3163e6 => 5
	i32 3486566296, ; 137: System.Transactions => 0xcfd0c798 => 78
	i32 3493954962, ; 138: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 26
	i32 3501239056, ; 139: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 22
	i32 3509114376, ; 140: System.Xml.Linq => 0xd128d608 => 14
	i32 3536029504, ; 141: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 69
	i32 3567349600, ; 142: System.ComponentModel.Composition.dll => 0xd4a16f60 => 82
	i32 3618140916, ; 143: Xamarin.AndroidX.Preference => 0xd7a872f4 => 54
	i32 3627220390, ; 144: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 55
	i32 3632359727, ; 145: Xamarin.Forms.Platform => 0xd881692f => 70
	i32 3633644679, ; 146: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 17
	i32 3641597786, ; 147: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 42
	i32 3672681054, ; 148: Mono.Android.dll => 0xdae8aa5e => 5
	i32 3676310014, ; 149: System.Web.Services.dll => 0xdb2009fe => 83
	i32 3682565725, ; 150: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 23
	i32 3684561358, ; 151: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 26
	i32 3689375977, ; 152: System.Drawing.Common => 0xdbe768e9 => 75
	i32 3718780102, ; 153: Xamarin.AndroidX.Annotation => 0xdda814c6 => 16
	i32 3724971120, ; 154: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 51
	i32 3758932259, ; 155: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 40
	i32 3786282454, ; 156: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 25
	i32 3822602673, ; 157: Xamarin.AndroidX.Media => 0xe3d849b1 => 49
	i32 3829621856, ; 158: System.Numerics.dll => 0xe4436460 => 10
	i32 3885922214, ; 159: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 61
	i32 3896760992, ; 160: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 30
	i32 3920810846, ; 161: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 81
	i32 3921031405, ; 162: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 64
	i32 3931092270, ; 163: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 53
	i32 3945713374, ; 164: System.Data.DataSetExtensions.dll => 0xeb2ecede => 79
	i32 3955647286, ; 165: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 19
	i32 4105002889, ; 166: Mono.Security.dll => 0xf4ad5f89 => 84
	i32 4151237749, ; 167: System.Core => 0xf76edc75 => 8
	i32 4182413190, ; 168: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 46
	i32 4292120959 ; 169: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 46
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [170 x i32] [
	i32 44, i32 73, i32 68, i32 58, i32 58, i32 25, i32 59, i32 23, ; 0..7
	i32 39, i32 83, i32 28, i32 43, i32 37, i32 15, i32 10, i32 0, ; 8..15
	i32 41, i32 27, i32 67, i32 36, i32 6, i32 9, i32 37, i32 48, ; 16..23
	i32 78, i32 81, i32 32, i32 64, i32 20, i32 14, i32 80, i32 75, ; 24..31
	i32 55, i32 7, i32 73, i32 7, i32 41, i32 3, i32 57, i32 19, ; 32..39
	i32 70, i32 45, i32 9, i32 62, i32 52, i32 20, i32 63, i32 34, ; 40..47
	i32 74, i32 57, i32 49, i32 29, i32 71, i32 80, i32 18, i32 33, ; 48..55
	i32 2, i32 47, i32 66, i32 31, i32 1, i32 12, i32 60, i32 72, ; 56..63
	i32 28, i32 24, i32 59, i32 8, i32 36, i32 47, i32 72, i32 53, ; 64..71
	i32 67, i32 71, i32 21, i32 50, i32 45, i32 42, i32 12, i32 11, ; 72..79
	i32 38, i32 69, i32 1, i32 62, i32 48, i32 50, i32 40, i32 56, ; 80..87
	i32 16, i32 54, i32 27, i32 76, i32 4, i32 79, i32 44, i32 63, ; 88..95
	i32 31, i32 35, i32 43, i32 60, i32 15, i32 18, i32 68, i32 65, ; 96..103
	i32 29, i32 13, i32 65, i32 61, i32 82, i32 6, i32 66, i32 11, ; 104..111
	i32 17, i32 0, i32 34, i32 39, i32 3, i32 51, i32 2, i32 77, ; 112..119
	i32 33, i32 84, i32 24, i32 22, i32 32, i32 77, i32 21, i32 52, ; 120..127
	i32 38, i32 30, i32 4, i32 56, i32 74, i32 13, i32 76, i32 35, ; 128..135
	i32 5, i32 78, i32 26, i32 22, i32 14, i32 69, i32 82, i32 54, ; 136..143
	i32 55, i32 70, i32 17, i32 42, i32 5, i32 83, i32 23, i32 26, ; 144..151
	i32 75, i32 16, i32 51, i32 40, i32 25, i32 49, i32 10, i32 61, ; 152..159
	i32 30, i32 81, i32 64, i32 53, i32 79, i32 19, i32 84, i32 8, ; 160..167
	i32 46, i32 46 ; 168..169
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="all" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ a8a26c7b003e2524cc98acb2c2ffc2ddea0f6692"}
!llvm.linker.options = !{}
