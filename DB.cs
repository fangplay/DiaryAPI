namespace DiaryAPI.DB;

public record Diary{
    public int Id { get; set; }
    public string ? Title { get; set; }
    puliic DateTime Date { get; set; }
}

public class DiaryDB
{
    private statoc List<Diary> _diary = new List<Diary>(){
        new Diary{ Id=1, Title="Setup Project Practice for work", Date="" }
        new Diary{ Id=2, Title="Get Study BA Course", Date="" }
    };

    public static List<Diary> GetDiaries()
    {
        return _diaries;
    }

    public static Diary ? GetDiary(int id)
    {
        return _diaries.SingleOrDefault(diary => diary.Id == id);
    }

    public static Diary CreateDiary(Diary diary)
    {
        _diaries.Add(diary);
        return diary;
    }

    public static Diary UpdateDiary(Diary update)
    {
        _diaries = _diaries.Select(diary =>{
            if(diary.Id == update.Id){
                diary.Title = update.Title;
            }
            return diary;
        }).ToList();
        return update;
    }

    public static void RemoveDiary(int id){
        _diaries = _diaries.FindAll(diary => diary.Id != id).ToList();
    }
}