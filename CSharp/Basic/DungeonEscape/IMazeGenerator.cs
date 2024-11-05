namespace DungeonEscape
{
    public interface IMazeGenerator : IMaze
    {
        public void GenerateMaze(byte size = 5, byte maxTraps = 5);
    }
}