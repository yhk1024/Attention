using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_List : MonoBehaviour
{
    public object[] talk0 = new object[]
    {
        "오늘도 피곤한 하루였다.", "난 식당에서 밥을 먹은 뒤, 가게에 들리기로 했다."
    };
    public object[] talk1 = new object[]
    {
        "피곤했기에 기운도 차릴 겸 맛집으로 왔다.", "난 만족스러운 식사를 마치고 식당을 나섰다.", "빨리 집에 가고 싶어 서둘러 가게로 향했다."
    };
    public object[] talk2 = new object[]
    {
        "가게에 도착한 난 필요한 물건들만 찾고 계산대로 갔다.", "평소라면 다른 물건들도 구경했겠지만 너무 피곤해 그럴 정신이 없었다.", "난 빨리 집에 돌아가 쉴 생각 뿐이었다."
    };
    public object[] talk3 = new object[]
    {
        "집에 돌아온 난 구매한 물건들을 대충 정리하고 곧장 침대에 몸을 던졌다.", "이대로 자고 싶었지만, 겨우 몸을 일으켜 욕실로 향했다.", "씻는 와중에도 피곤이 몰려왔다.", "겨우 다 씻은 난 다시 침대에 들어갔다.", "난 금새 잠에 빠졌다."
    };
    public object[] talk4 = new object[]
    {
        "난 아침이 되자마자 눈을 떴다.", "오랜만에 친구와 만나는 날이라 그런지 일찍 눈이 떠졌다.", "난 서둘러 준비한 뒤, 만나기로 한 식당으로 향했다."
    };
    public object[] talk5 = new object[]
    {
        "식당 앞으로 가자 친구가 먼저 나와 있는 것이 보였다.", "오랜만에 만난 터라 반가운 마음부터 들었다.", "반갑게 인사한 우리는 우선 식당 안으로 들어가기로 했다."
    };
    public object[] talk6 = new object[]
    {
        "이 식당은 친구의 단골 식당이다.", "그래서 만나기로 한 날에는 항상 이 식당에 와서 같이 밥을 먹는다.", "오랜만에 먹으니 꽤 맛있었다.", "잠시 후, 친구는 일이 있어서 먼저 일어나야 했다.", "벌써 헤어지는 것이 아쉽지만, 어쩔 수 없었다.", "난 잠시 가게에 들렸다가 집으로 돌아가기로 했다."
    };
    public object[] talk7 = new object[]
    {
        "오늘은 피곤하지 않아 마음껏 가게 안을 돌아다녔다.", "급한 물건들은 어제 산 덕분에 장바구니는 무겁지 않았다.", "한참을 구경하다 계산을 마친 난 집으로 돌아가기로 했다."
    };
    public object[] talk8 = new object[]
    {
        "집으로 가던 길에 오리들이 얼룩오리를 가게에서 내보내는 모습이 보였다.", "난 내가 어제 먹었던 식당이 얼룩오리 출입금지 가게였다는 것을 새삼 깨달았다.", "세상은 얼룩오리를 차별하고 멸시한다.", "새삼 그 사실을 깨달았다.", "난 얼룩오리인 내 친구를 떠올릴며 씁쓸히 집으로 돌아갔다."
    };

    public object[] GetArray(int id)
    {
        switch (id)
        {
            case 0:
                return talk0;
            case 1:
                return talk1;
            case 2:
                return talk2;
            case 3:
                return talk3;
            case 4:
                return talk4;
            case 5:
                return talk5;
            case 6:
                return talk6;
            case 7:
                return talk7;
            case 8:
                return talk8;
            default:
                return null;
        }
    }
}
