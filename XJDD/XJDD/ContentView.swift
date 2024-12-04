import SwiftUI

struct ContentView: View {
    var body: some View {
        VStack {
            // 顶部标题
            Text("洗脚大队App")
                .font(.largeTitle)
                .foregroundColor(.blue) // 标题颜色
                .padding()

            // 中心图标
            Image(systemName: "figure.wave")
                .resizable()
                .scaledToFit()
                .frame(width: 150, height: 150)
                .foregroundColor(.blue)
                .padding()

            // 操作按钮
            Button(action: {
                print("开始洗脚")
            }){
                Text("开始洗脚")
                    .font(.title2)
                    .foregroundColor(.white)
                    .padding()
                    .background(Color.blue)
                    .cornerRadius(10)
                    .frame(width: 200, height: 100)
                    .cornerRadius(50)
            }
            .padding()
        }
        .padding()// 设置背景色
        .cornerRadius(20) // 增加圆角效果
        .shadow(radius: 10) // 阴影
    }
}

#Preview {
    ContentView()
}
