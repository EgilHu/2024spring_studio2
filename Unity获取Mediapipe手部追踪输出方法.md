# Unity获取Mediapipe手部追踪输出方法

简单记录如何从Unity的Mediapipe plugin中获取手部追踪输出

<!--more-->

![image-20240330152448538](Unity获取Mediapipe手部追踪输出方法/image-20240330152448538.png)

在HandTrackingSolution.cs中有OnxxxxxOutput这几个函数，在这几个函数中可以得到Mediapipe的手部追踪输出，其中在OnHandWorldLandmarksOutput和OnHandLandmarksOutput这两个函数可以获取手部关键点输出。

![image-20240330153855768](Unity获取Mediapipe手部追踪输出方法/image-20240330153855768.png)

例如在OnHandLandmarksOutput这一函数中可以调用其他脚本的public函数，并将OnHandLandmarksOutput获取的value当作参数传入，这里的value是一个包含NormalizedLandmarkList的List，因为其可能包含两只手，这里只分析一只手的情况。

![image-20240330154848102](Unity获取Mediapipe手部追踪输出方法/image-20240330154848102.png)

在GetHandLandmarks这一示例函数中，首先判断landmarkList是否为null，再获取landmarklist中的手部21个关键点，21个关键点对应位置如下图

![image-20240330155027431](Unity获取Mediapipe手部追踪输出方法/image-20240330155027431.png)

要获取每个关键点的3D位置，可以通过handLandmarkList.Landmark[x].X(Y/Z)来得到。注意从OnHandLandmarksOutput获取的手部关键点的x和y是根据相机分辨率Normalize，z是以手腕为原点，而从OnHandWorldLandmarksOutput获取的手部关键点x,y是在世界坐标系下，z是以手部几何中心为原点，参考下图

![image-20240330155652978](Unity获取Mediapipe手部追踪输出方法/image-20240330155652978.png)



参考：

[Hand landmarks detection guide  | MediaPipe  | Google for Developers](https://developers.google.cn/mediapipe/solutions/vision/hand_landmarker)