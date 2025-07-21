; ModuleID = 'marshal_methods.x86.ll'
source_filename = "marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [147 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [294 x i32] [
	i32 42639949, ; 0: System.Threading.Thread => 0x28aa24d => 137
	i32 67008169, ; 1: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 33
	i32 72070932, ; 2: Microsoft.Maui.Graphics.dll => 0x44bb714 => 58
	i32 117431740, ; 3: System.Runtime.InteropServices => 0x6ffddbc => 129
	i32 182336117, ; 4: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 89
	i32 195452805, ; 5: vi/Microsoft.Maui.Controls.resources.dll => 0xba65f85 => 30
	i32 199333315, ; 6: zh-HK/Microsoft.Maui.Controls.resources.dll => 0xbe195c3 => 31
	i32 205061960, ; 7: System.ComponentModel => 0xc38ff48 => 107
	i32 209399409, ; 8: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 68
	i32 230752869, ; 9: Microsoft.CSharp.dll => 0xdc10265 => 100
	i32 254259026, ; 10: Microsoft.AspNetCore.Components.dll => 0xf27af52 => 36
	i32 280992041, ; 11: cs/Microsoft.Maui.Controls.resources.dll => 0x10bf9929 => 2
	i32 317674968, ; 12: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 30
	i32 318968648, ; 13: Xamarin.AndroidX.Activity.dll => 0x13031348 => 65
	i32 336156722, ; 14: ja/Microsoft.Maui.Controls.resources.dll => 0x14095832 => 15
	i32 342366114, ; 15: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 77
	i32 347068432, ; 16: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0x14afd810 => 63
	i32 356389973, ; 17: it/Microsoft.Maui.Controls.resources.dll => 0x153e1455 => 14
	i32 379916513, ; 18: System.Threading.Thread.dll => 0x16a510e1 => 137
	i32 385762202, ; 19: System.Memory.dll => 0x16fe439a => 116
	i32 395744057, ; 20: _Microsoft.Android.Resource.Designer => 0x17969339 => 34
	i32 435591531, ; 21: sv/Microsoft.Maui.Controls.resources.dll => 0x19f6996b => 26
	i32 442565967, ; 22: System.Collections => 0x1a61054f => 104
	i32 450948140, ; 23: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 76
	i32 458821065, ; 24: Xamarin.GooglePlayServices.Ads.Lite => 0x1b590dc9 => 94
	i32 459347974, ; 25: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 131
	i32 469710990, ; 26: System.dll => 0x1bff388e => 141
	i32 498788369, ; 27: System.ObjectModel => 0x1dbae811 => 121
	i32 500358224, ; 28: id/Microsoft.Maui.Controls.resources.dll => 0x1dd2dc50 => 13
	i32 503918385, ; 29: fi/Microsoft.Maui.Controls.resources.dll => 0x1e092f31 => 7
	i32 513247710, ; 30: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 52
	i32 530272170, ; 31: System.Linq.Queryable => 0x1f9b4faa => 114
	i32 539058512, ; 32: Microsoft.Extensions.Logging => 0x20216150 => 49
	i32 571435654, ; 33: Microsoft.Extensions.FileProviders.Embedded.dll => 0x220f6a86 => 46
	i32 592146354, ; 34: pt-BR/Microsoft.Maui.Controls.resources.dll => 0x234b6fb2 => 21
	i32 627609679, ; 35: Xamarin.AndroidX.CustomView => 0x2568904f => 74
	i32 627931235, ; 36: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 19
	i32 662205335, ; 37: System.Text.Encodings.Web.dll => 0x27787397 => 134
	i32 672442732, ; 38: System.Collections.Concurrent => 0x2814a96c => 101
	i32 688181140, ; 39: ca/Microsoft.Maui.Controls.resources.dll => 0x2904cf94 => 1
	i32 690569205, ; 40: System.Xml.Linq.dll => 0x29293ff5 => 139
	i32 699345723, ; 41: System.Reflection.Emit => 0x29af2b3b => 126
	i32 706645707, ; 42: ko/Microsoft.Maui.Controls.resources.dll => 0x2a1e8ecb => 16
	i32 709557578, ; 43: de/Microsoft.Maui.Controls.resources.dll => 0x2a4afd4a => 4
	i32 722857257, ; 44: System.Runtime.Loader.dll => 0x2b15ed29 => 130
	i32 748832960, ; 45: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 61
	i32 759454413, ; 46: System.Net.Requests => 0x2d445acd => 119
	i32 775507847, ; 47: System.IO.Compression => 0x2e394f87 => 111
	i32 777317022, ; 48: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 25
	i32 789151979, ; 49: Microsoft.Extensions.Options => 0x2f0980eb => 51
	i32 804008546, ; 50: Microsoft.AspNetCore.Components.WebView.Maui => 0x2fec3262 => 39
	i32 823281589, ; 51: System.Private.Uri.dll => 0x311247b5 => 122
	i32 830298997, ; 52: System.IO.Compression.Brotli => 0x317d5b75 => 110
	i32 893593324, ; 53: Xamarin.GooglePlayServices.Ads.Lite.dll => 0x354326ec => 94
	i32 904024072, ; 54: System.ComponentModel.Primitives.dll => 0x35e25008 => 105
	i32 921176573, ; 55: PlayMatch.Front.dll => 0x36e809fd => 99
	i32 926902833, ; 56: tr/Microsoft.Maui.Controls.resources.dll => 0x373f6a31 => 28
	i32 967690846, ; 57: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 77
	i32 992768348, ; 58: System.Collections.dll => 0x3b2c715c => 104
	i32 999186168, ; 59: Microsoft.Extensions.FileSystemGlobbing.dll => 0x3b8e5ef8 => 48
	i32 1012816738, ; 60: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 88
	i32 1028951442, ; 61: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 43
	i32 1029334545, ; 62: da/Microsoft.Maui.Controls.resources.dll => 0x3d5a6611 => 3
	i32 1035644815, ; 63: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 66
	i32 1044663988, ; 64: System.Linq.Expressions.dll => 0x3e444eb4 => 113
	i32 1082857460, ; 65: System.ComponentModel.TypeConverter => 0x408b17f4 => 106
	i32 1084122840, ; 66: Xamarin.Kotlin.StdLib => 0x409e66d8 => 96
	i32 1098259244, ; 67: System => 0x41761b2c => 141
	i32 1118262833, ; 68: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 16
	i32 1168523401, ; 69: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 22
	i32 1173126369, ; 70: Microsoft.Extensions.FileProviders.Abstractions.dll => 0x45ec7ce1 => 44
	i32 1178241025, ; 71: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 85
	i32 1185513792, ; 72: Xamarin.Google.UserMessagingPlatform.dll => 0x46a98140 => 93
	i32 1203215381, ; 73: pl/Microsoft.Maui.Controls.resources.dll => 0x47b79c15 => 20
	i32 1234928153, ; 74: nb/Microsoft.Maui.Controls.resources.dll => 0x499b8219 => 18
	i32 1246548578, ; 75: Xamarin.AndroidX.Collection.Jvm.dll => 0x4a4cd262 => 70
	i32 1260983243, ; 76: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 2
	i32 1292207520, ; 77: SQLitePCLRaw.core.dll => 0x4d0585a0 => 62
	i32 1293217323, ; 78: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 75
	i32 1304657261, ; 79: Plugin.MauiMtAdmob.dll => 0x4dc37d6d => 59
	i32 1324164729, ; 80: System.Linq => 0x4eed2679 => 115
	i32 1373134921, ; 81: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 32
	i32 1376866003, ; 82: Xamarin.AndroidX.SavedState => 0x52114ed3 => 88
	i32 1406073936, ; 83: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 71
	i32 1430672901, ; 84: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 0
	i32 1437299793, ; 85: Xamarin.AndroidX.Lifecycle.Common.Jvm => 0x55ab7451 => 78
	i32 1441095154, ; 86: Xamarin.AndroidX.Lifecycle.ViewModel.Android => 0x55e55df2 => 80
	i32 1452416952, ; 87: AutoMapper => 0x56921fb8 => 35
	i32 1454105418, ; 88: Microsoft.Extensions.FileProviders.Composite => 0x56abe34a => 45
	i32 1461004990, ; 89: es\Microsoft.Maui.Controls.resources => 0x57152abe => 6
	i32 1462112819, ; 90: System.IO.Compression.dll => 0x57261233 => 111
	i32 1469204771, ; 91: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 67
	i32 1470490898, ; 92: Microsoft.Extensions.Primitives => 0x57a5e912 => 52
	i32 1480492111, ; 93: System.IO.Compression.Brotli.dll => 0x583e844f => 110
	i32 1493001747, ; 94: hi/Microsoft.Maui.Controls.resources.dll => 0x58fd6613 => 10
	i32 1514721132, ; 95: el/Microsoft.Maui.Controls.resources.dll => 0x5a48cf6c => 5
	i32 1521091094, ; 96: Microsoft.Extensions.FileSystemGlobbing => 0x5aaa0216 => 48
	i32 1543031311, ; 97: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 136
	i32 1543355203, ; 98: System.Reflection.Emit.dll => 0x5bfdbb43 => 126
	i32 1546581739, ; 99: Microsoft.AspNetCore.Components.WebView.Maui.dll => 0x5c2ef6eb => 39
	i32 1551623176, ; 100: sk/Microsoft.Maui.Controls.resources.dll => 0x5c7be408 => 25
	i32 1622152042, ; 101: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 82
	i32 1624863272, ; 102: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 91
	i32 1636350590, ; 103: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 73
	i32 1639515021, ; 104: System.Net.Http.dll => 0x61b9038d => 117
	i32 1639986890, ; 105: System.Text.RegularExpressions => 0x61c036ca => 136
	i32 1654881142, ; 106: Microsoft.AspNetCore.Components.WebView => 0x62a37b76 => 38
	i32 1657153582, ; 107: System.Runtime => 0x62c6282e => 132
	i32 1658251792, ; 108: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 92
	i32 1677501392, ; 109: System.Net.Primitives.dll => 0x63fca3d0 => 118
	i32 1679769178, ; 110: System.Security.Cryptography => 0x641f3e5a => 133
	i32 1711441057, ; 111: SQLitePCLRaw.lib.e_sqlite3.android => 0x660284a1 => 63
	i32 1729485958, ; 112: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 69
	i32 1736233607, ; 113: ro/Microsoft.Maui.Controls.resources.dll => 0x677cd287 => 23
	i32 1743415430, ; 114: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 1
	i32 1760259689, ; 115: Microsoft.AspNetCore.Components.Web.dll => 0x68eb6e69 => 37
	i32 1766324549, ; 116: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 89
	i32 1770582343, ; 117: Microsoft.Extensions.Logging.dll => 0x6988f147 => 49
	i32 1780572499, ; 118: Mono.Android.Runtime.dll => 0x6a216153 => 145
	i32 1782862114, ; 119: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 17
	i32 1788241197, ; 120: Xamarin.AndroidX.Fragment => 0x6a96652d => 76
	i32 1793755602, ; 121: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 9
	i32 1808609942, ; 122: Xamarin.AndroidX.Loader => 0x6bcd3296 => 82
	i32 1813058853, ; 123: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 96
	i32 1813201214, ; 124: Xamarin.Google.Android.Material => 0x6c13413e => 92
	i32 1818569960, ; 125: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 86
	i32 1828688058, ; 126: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 50
	i32 1842015223, ; 127: uk/Microsoft.Maui.Controls.resources.dll => 0x6dcaebf7 => 29
	i32 1853025655, ; 128: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 26
	i32 1858542181, ; 129: System.Linq.Expressions => 0x6ec71a65 => 113
	i32 1870277092, ; 130: System.Reflection.Primitives => 0x6f7a29e4 => 127
	i32 1875935024, ; 131: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 8
	i32 1908813208, ; 132: Xamarin.GooglePlayServices.Basement => 0x71c62d98 => 95
	i32 1910275211, ; 133: System.Collections.NonGeneric.dll => 0x71dc7c8b => 102
	i32 1939592360, ; 134: System.Private.Xml.Linq => 0x739bd4a8 => 123
	i32 1968388702, ; 135: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 40
	i32 2003115576, ; 136: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 5
	i32 2025202353, ; 137: ar/Microsoft.Maui.Controls.resources.dll => 0x78b622b1 => 0
	i32 2031445118, ; 138: AutoMapper.dll => 0x7915647e => 35
	i32 2045470958, ; 139: System.Private.Xml => 0x79eb68ee => 124
	i32 2055257422, ; 140: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 79
	i32 2066184531, ; 141: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 4
	i32 2072397586, ; 142: Microsoft.Extensions.FileProviders.Physical => 0x7b864712 => 47
	i32 2079903147, ; 143: System.Runtime.dll => 0x7bf8cdab => 132
	i32 2090596640, ; 144: System.Numerics.Vectors => 0x7c9bf920 => 120
	i32 2100186672, ; 145: Plugin.MauiMtAdmob => 0x7d2e4e30 => 59
	i32 2103459038, ; 146: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 64
	i32 2127167465, ; 147: System.Console => 0x7ec9ffe9 => 108
	i32 2142473426, ; 148: System.Collections.Specialized => 0x7fb38cd2 => 103
	i32 2159891885, ; 149: Microsoft.Maui => 0x80bd55ad => 56
	i32 2169148018, ; 150: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 12
	i32 2181898931, ; 151: Microsoft.Extensions.Options.dll => 0x820d22b3 => 51
	i32 2192057212, ; 152: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 50
	i32 2193016926, ; 153: System.ObjectModel.dll => 0x82b6c85e => 121
	i32 2201107256, ; 154: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 97
	i32 2201231467, ; 155: System.Net.Http => 0x8334206b => 117
	i32 2207618523, ; 156: it\Microsoft.Maui.Controls.resources => 0x839595db => 14
	i32 2266799131, ; 157: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 41
	i32 2270573516, ; 158: fr/Microsoft.Maui.Controls.resources.dll => 0x875633cc => 8
	i32 2279755925, ; 159: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 87
	i32 2303942373, ; 160: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 18
	i32 2305521784, ; 161: System.Private.CoreLib.dll => 0x896b7878 => 143
	i32 2340441535, ; 162: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 128
	i32 2353062107, ; 163: System.Net.Primitives => 0x8c40e0db => 118
	i32 2368005991, ; 164: System.Xml.ReaderWriter.dll => 0x8d24e767 => 140
	i32 2371007202, ; 165: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 40
	i32 2395872292, ; 166: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 13
	i32 2411328690, ; 167: Microsoft.AspNetCore.Components => 0x8fb9f4b2 => 36
	i32 2427813419, ; 168: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 10
	i32 2435356389, ; 169: System.Console.dll => 0x912896e5 => 108
	i32 2442556106, ; 170: Microsoft.JSInterop.dll => 0x919672ca => 53
	i32 2465273461, ; 171: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 61
	i32 2471841756, ; 172: netstandard.dll => 0x93554fdc => 142
	i32 2475788418, ; 173: Java.Interop.dll => 0x93918882 => 144
	i32 2480646305, ; 174: Microsoft.Maui.Controls => 0x93dba8a1 => 54
	i32 2550873716, ; 175: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 11
	i32 2562349572, ; 176: Microsoft.CSharp => 0x98ba5a04 => 100
	i32 2570120770, ; 177: System.Text.Encodings.Web => 0x9930ee42 => 134
	i32 2592341985, ; 178: Microsoft.Extensions.FileProviders.Abstractions => 0x9a83ffe1 => 44
	i32 2593496499, ; 179: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 20
	i32 2605712449, ; 180: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 97
	i32 2617129537, ; 181: System.Private.Xml.dll => 0x9bfe3a41 => 124
	i32 2620871830, ; 182: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 73
	i32 2626831493, ; 183: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 15
	i32 2663698177, ; 184: System.Runtime.Loader => 0x9ec4cf01 => 130
	i32 2692077919, ; 185: Microsoft.AspNetCore.Components.WebView.dll => 0xa075d95f => 38
	i32 2732626843, ; 186: Xamarin.AndroidX.Activity => 0xa2e0939b => 65
	i32 2737747696, ; 187: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 67
	i32 2752995522, ; 188: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 21
	i32 2758225723, ; 189: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 55
	i32 2764765095, ; 190: Microsoft.Maui.dll => 0xa4caf7a7 => 56
	i32 2766642685, ; 191: Xamarin.AndroidX.Lifecycle.ViewModel.Android.dll => 0xa4e79dfd => 80
	i32 2778768386, ; 192: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 90
	i32 2780199943, ; 193: Xamarin.AndroidX.Lifecycle.Common.Jvm.dll => 0xa5b67c07 => 78
	i32 2785988530, ; 194: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 27
	i32 2801831435, ; 195: Microsoft.Maui.Graphics => 0xa7008e0b => 58
	i32 2806116107, ; 196: es/Microsoft.Maui.Controls.resources.dll => 0xa741ef0b => 6
	i32 2810250172, ; 197: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 71
	i32 2831556043, ; 198: nl/Microsoft.Maui.Controls.resources.dll => 0xa8c61dcb => 19
	i32 2853208004, ; 199: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 90
	i32 2861189240, ; 200: Microsoft.Maui.Essentials => 0xaa8a4878 => 57
	i32 2892341533, ; 201: Microsoft.AspNetCore.Components.Web => 0xac65a11d => 37
	i32 2909740682, ; 202: System.Private.CoreLib => 0xad6f1e8a => 143
	i32 2911054922, ; 203: Microsoft.Extensions.FileProviders.Physical.dll => 0xad832c4a => 47
	i32 2916838712, ; 204: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 91
	i32 2919462931, ; 205: System.Numerics.Vectors.dll => 0xae037813 => 120
	i32 2959614098, ; 206: System.ComponentModel.dll => 0xb0682092 => 107
	i32 2978675010, ; 207: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 75
	i32 3009947449, ; 208: PlayMatch.Core.dll => 0xb3682739 => 98
	i32 3038032645, ; 209: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 34
	i32 3057625584, ; 210: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 83
	i32 3059408633, ; 211: Mono.Android.Runtime => 0xb65adef9 => 145
	i32 3059793426, ; 212: System.ComponentModel.Primitives => 0xb660be12 => 105
	i32 3077302341, ; 213: hu/Microsoft.Maui.Controls.resources.dll => 0xb76be845 => 12
	i32 3159123045, ; 214: System.Reflection.Primitives.dll => 0xbc4c6465 => 127
	i32 3178803400, ; 215: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 84
	i32 3220365878, ; 216: System.Threading => 0xbff2e236 => 138
	i32 3230466174, ; 217: Xamarin.GooglePlayServices.Basement.dll => 0xc08d007e => 95
	i32 3258312781, ; 218: Xamarin.AndroidX.CardView => 0xc235e84d => 69
	i32 3265493905, ; 219: System.Linq.Queryable.dll => 0xc2a37b91 => 114
	i32 3286872994, ; 220: SQLite-net.dll => 0xc3e9b3a2 => 60
	i32 3305363605, ; 221: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 7
	i32 3316684772, ; 222: System.Net.Requests.dll => 0xc5b097e4 => 119
	i32 3317135071, ; 223: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 74
	i32 3346324047, ; 224: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 85
	i32 3357674450, ; 225: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 24
	i32 3358260929, ; 226: System.Text.Json => 0xc82afec1 => 135
	i32 3360279109, ; 227: SQLitePCLRaw.core => 0xc849ca45 => 62
	i32 3362522851, ; 228: Xamarin.AndroidX.Core => 0xc86c06e3 => 72
	i32 3366347497, ; 229: Java.Interop => 0xc8a662e9 => 144
	i32 3374999561, ; 230: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 87
	i32 3381016424, ; 231: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 3
	i32 3406629867, ; 232: Microsoft.Extensions.FileProviders.Composite.dll => 0xcb0d0beb => 45
	i32 3428513518, ; 233: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 42
	i32 3430777524, ; 234: netstandard => 0xcc7d82b4 => 142
	i32 3463511458, ; 235: hr/Microsoft.Maui.Controls.resources.dll => 0xce70fda2 => 11
	i32 3471940407, ; 236: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 106
	i32 3476120550, ; 237: Mono.Android => 0xcf3163e6 => 146
	i32 3479583265, ; 238: ru/Microsoft.Maui.Controls.resources.dll => 0xcf663a21 => 24
	i32 3484440000, ; 239: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 23
	i32 3485074729, ; 240: PlayMatch.Core => 0xcfba0529 => 98
	i32 3485117614, ; 241: System.Text.Json.dll => 0xcfbaacae => 135
	i32 3500000672, ; 242: Microsoft.JSInterop => 0xd09dc5a0 => 53
	i32 3509114376, ; 243: System.Xml.Linq => 0xd128d608 => 139
	i32 3580758918, ; 244: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 31
	i32 3608519521, ; 245: System.Linq.dll => 0xd715a361 => 115
	i32 3624195450, ; 246: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 128
	i32 3641597786, ; 247: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 79
	i32 3643446276, ; 248: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 28
	i32 3643854240, ; 249: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 84
	i32 3657292374, ; 250: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 41
	i32 3672681054, ; 251: Mono.Android.dll => 0xdae8aa5e => 146
	i32 3682565725, ; 252: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 68
	i32 3697841164, ; 253: zh-Hant/Microsoft.Maui.Controls.resources.dll => 0xdc68940c => 33
	i32 3724971120, ; 254: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 83
	i32 3748608112, ; 255: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 109
	i32 3754567612, ; 256: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 64
	i32 3792276235, ; 257: System.Collections.NonGeneric => 0xe2098b0b => 102
	i32 3802395368, ; 258: System.Collections.Specialized.dll => 0xe2a3f2e8 => 103
	i32 3823082795, ; 259: System.Security.Cryptography.dll => 0xe3df9d2b => 133
	i32 3841636137, ; 260: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 43
	i32 3849253459, ; 261: System.Runtime.InteropServices.dll => 0xe56ef253 => 129
	i32 3876362041, ; 262: SQLite-net => 0xe70c9739 => 60
	i32 3889960447, ; 263: zh-Hans/Microsoft.Maui.Controls.resources.dll => 0xe7dc15ff => 32
	i32 3896106733, ; 264: System.Collections.Concurrent.dll => 0xe839deed => 101
	i32 3896760992, ; 265: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 72
	i32 3910130544, ; 266: Xamarin.AndroidX.Collection.Jvm => 0xe90fdb70 => 70
	i32 3928044579, ; 267: System.Xml.ReaderWriter => 0xea213423 => 140
	i32 3931092270, ; 268: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 86
	i32 3955647286, ; 269: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 66
	i32 3980434154, ; 270: th/Microsoft.Maui.Controls.resources.dll => 0xed409aea => 27
	i32 3987592930, ; 271: he/Microsoft.Maui.Controls.resources.dll => 0xedadd6e2 => 9
	i32 4025784931, ; 272: System.Memory => 0xeff49a63 => 116
	i32 4046471985, ; 273: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 55
	i32 4054681211, ; 274: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 125
	i32 4068434129, ; 275: System.Private.Xml.Linq.dll => 0xf27f60d1 => 123
	i32 4073602200, ; 276: System.Threading.dll => 0xf2ce3c98 => 138
	i32 4094352644, ; 277: Microsoft.Maui.Essentials.dll => 0xf40add04 => 57
	i32 4099395768, ; 278: PlayMatch.Front => 0xf457d0b8 => 99
	i32 4100113165, ; 279: System.Private.Uri => 0xf462c30d => 122
	i32 4102112229, ; 280: pt/Microsoft.Maui.Controls.resources.dll => 0xf48143e5 => 22
	i32 4125707920, ; 281: ms/Microsoft.Maui.Controls.resources.dll => 0xf5e94e90 => 17
	i32 4126470640, ; 282: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 42
	i32 4127667938, ; 283: System.IO.FileSystem.Watcher => 0xf60736e2 => 112
	i32 4147896353, ; 284: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 125
	i32 4150914736, ; 285: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 29
	i32 4164802419, ; 286: System.IO.FileSystem.Watcher.dll => 0xf83dd773 => 112
	i32 4167421510, ; 287: Xamarin.Google.UserMessagingPlatform => 0xf865ce46 => 93
	i32 4181436372, ; 288: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 131
	i32 4182413190, ; 289: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 81
	i32 4213026141, ; 290: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 109
	i32 4271975918, ; 291: Microsoft.Maui.Controls.dll => 0xfea12dee => 54
	i32 4292120959, ; 292: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 81
	i32 4294648842 ; 293: Microsoft.Extensions.FileProviders.Embedded => 0xfffb240a => 46
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [294 x i32] [
	i32 137, ; 0
	i32 33, ; 1
	i32 58, ; 2
	i32 129, ; 3
	i32 89, ; 4
	i32 30, ; 5
	i32 31, ; 6
	i32 107, ; 7
	i32 68, ; 8
	i32 100, ; 9
	i32 36, ; 10
	i32 2, ; 11
	i32 30, ; 12
	i32 65, ; 13
	i32 15, ; 14
	i32 77, ; 15
	i32 63, ; 16
	i32 14, ; 17
	i32 137, ; 18
	i32 116, ; 19
	i32 34, ; 20
	i32 26, ; 21
	i32 104, ; 22
	i32 76, ; 23
	i32 94, ; 24
	i32 131, ; 25
	i32 141, ; 26
	i32 121, ; 27
	i32 13, ; 28
	i32 7, ; 29
	i32 52, ; 30
	i32 114, ; 31
	i32 49, ; 32
	i32 46, ; 33
	i32 21, ; 34
	i32 74, ; 35
	i32 19, ; 36
	i32 134, ; 37
	i32 101, ; 38
	i32 1, ; 39
	i32 139, ; 40
	i32 126, ; 41
	i32 16, ; 42
	i32 4, ; 43
	i32 130, ; 44
	i32 61, ; 45
	i32 119, ; 46
	i32 111, ; 47
	i32 25, ; 48
	i32 51, ; 49
	i32 39, ; 50
	i32 122, ; 51
	i32 110, ; 52
	i32 94, ; 53
	i32 105, ; 54
	i32 99, ; 55
	i32 28, ; 56
	i32 77, ; 57
	i32 104, ; 58
	i32 48, ; 59
	i32 88, ; 60
	i32 43, ; 61
	i32 3, ; 62
	i32 66, ; 63
	i32 113, ; 64
	i32 106, ; 65
	i32 96, ; 66
	i32 141, ; 67
	i32 16, ; 68
	i32 22, ; 69
	i32 44, ; 70
	i32 85, ; 71
	i32 93, ; 72
	i32 20, ; 73
	i32 18, ; 74
	i32 70, ; 75
	i32 2, ; 76
	i32 62, ; 77
	i32 75, ; 78
	i32 59, ; 79
	i32 115, ; 80
	i32 32, ; 81
	i32 88, ; 82
	i32 71, ; 83
	i32 0, ; 84
	i32 78, ; 85
	i32 80, ; 86
	i32 35, ; 87
	i32 45, ; 88
	i32 6, ; 89
	i32 111, ; 90
	i32 67, ; 91
	i32 52, ; 92
	i32 110, ; 93
	i32 10, ; 94
	i32 5, ; 95
	i32 48, ; 96
	i32 136, ; 97
	i32 126, ; 98
	i32 39, ; 99
	i32 25, ; 100
	i32 82, ; 101
	i32 91, ; 102
	i32 73, ; 103
	i32 117, ; 104
	i32 136, ; 105
	i32 38, ; 106
	i32 132, ; 107
	i32 92, ; 108
	i32 118, ; 109
	i32 133, ; 110
	i32 63, ; 111
	i32 69, ; 112
	i32 23, ; 113
	i32 1, ; 114
	i32 37, ; 115
	i32 89, ; 116
	i32 49, ; 117
	i32 145, ; 118
	i32 17, ; 119
	i32 76, ; 120
	i32 9, ; 121
	i32 82, ; 122
	i32 96, ; 123
	i32 92, ; 124
	i32 86, ; 125
	i32 50, ; 126
	i32 29, ; 127
	i32 26, ; 128
	i32 113, ; 129
	i32 127, ; 130
	i32 8, ; 131
	i32 95, ; 132
	i32 102, ; 133
	i32 123, ; 134
	i32 40, ; 135
	i32 5, ; 136
	i32 0, ; 137
	i32 35, ; 138
	i32 124, ; 139
	i32 79, ; 140
	i32 4, ; 141
	i32 47, ; 142
	i32 132, ; 143
	i32 120, ; 144
	i32 59, ; 145
	i32 64, ; 146
	i32 108, ; 147
	i32 103, ; 148
	i32 56, ; 149
	i32 12, ; 150
	i32 51, ; 151
	i32 50, ; 152
	i32 121, ; 153
	i32 97, ; 154
	i32 117, ; 155
	i32 14, ; 156
	i32 41, ; 157
	i32 8, ; 158
	i32 87, ; 159
	i32 18, ; 160
	i32 143, ; 161
	i32 128, ; 162
	i32 118, ; 163
	i32 140, ; 164
	i32 40, ; 165
	i32 13, ; 166
	i32 36, ; 167
	i32 10, ; 168
	i32 108, ; 169
	i32 53, ; 170
	i32 61, ; 171
	i32 142, ; 172
	i32 144, ; 173
	i32 54, ; 174
	i32 11, ; 175
	i32 100, ; 176
	i32 134, ; 177
	i32 44, ; 178
	i32 20, ; 179
	i32 97, ; 180
	i32 124, ; 181
	i32 73, ; 182
	i32 15, ; 183
	i32 130, ; 184
	i32 38, ; 185
	i32 65, ; 186
	i32 67, ; 187
	i32 21, ; 188
	i32 55, ; 189
	i32 56, ; 190
	i32 80, ; 191
	i32 90, ; 192
	i32 78, ; 193
	i32 27, ; 194
	i32 58, ; 195
	i32 6, ; 196
	i32 71, ; 197
	i32 19, ; 198
	i32 90, ; 199
	i32 57, ; 200
	i32 37, ; 201
	i32 143, ; 202
	i32 47, ; 203
	i32 91, ; 204
	i32 120, ; 205
	i32 107, ; 206
	i32 75, ; 207
	i32 98, ; 208
	i32 34, ; 209
	i32 83, ; 210
	i32 145, ; 211
	i32 105, ; 212
	i32 12, ; 213
	i32 127, ; 214
	i32 84, ; 215
	i32 138, ; 216
	i32 95, ; 217
	i32 69, ; 218
	i32 114, ; 219
	i32 60, ; 220
	i32 7, ; 221
	i32 119, ; 222
	i32 74, ; 223
	i32 85, ; 224
	i32 24, ; 225
	i32 135, ; 226
	i32 62, ; 227
	i32 72, ; 228
	i32 144, ; 229
	i32 87, ; 230
	i32 3, ; 231
	i32 45, ; 232
	i32 42, ; 233
	i32 142, ; 234
	i32 11, ; 235
	i32 106, ; 236
	i32 146, ; 237
	i32 24, ; 238
	i32 23, ; 239
	i32 98, ; 240
	i32 135, ; 241
	i32 53, ; 242
	i32 139, ; 243
	i32 31, ; 244
	i32 115, ; 245
	i32 128, ; 246
	i32 79, ; 247
	i32 28, ; 248
	i32 84, ; 249
	i32 41, ; 250
	i32 146, ; 251
	i32 68, ; 252
	i32 33, ; 253
	i32 83, ; 254
	i32 109, ; 255
	i32 64, ; 256
	i32 102, ; 257
	i32 103, ; 258
	i32 133, ; 259
	i32 43, ; 260
	i32 129, ; 261
	i32 60, ; 262
	i32 32, ; 263
	i32 101, ; 264
	i32 72, ; 265
	i32 70, ; 266
	i32 140, ; 267
	i32 86, ; 268
	i32 66, ; 269
	i32 27, ; 270
	i32 9, ; 271
	i32 116, ; 272
	i32 55, ; 273
	i32 125, ; 274
	i32 123, ; 275
	i32 138, ; 276
	i32 57, ; 277
	i32 99, ; 278
	i32 122, ; 279
	i32 22, ; 280
	i32 17, ; 281
	i32 42, ; 282
	i32 112, ; 283
	i32 125, ; 284
	i32 29, ; 285
	i32 112, ; 286
	i32 93, ; 287
	i32 131, ; 288
	i32 81, ; 289
	i32 109, ; 290
	i32 54, ; 291
	i32 81, ; 292
	i32 46 ; 293
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nofree norecurse nosync nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: "no-trapping-math"="true" noreturn nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nofree norecurse nosync nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { "no-trapping-math"="true" noreturn nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.4xx @ a8cd27e430e55df3e3c1e3a43d35c11d9512a2db"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"NumRegisterParameters", i32 0}
