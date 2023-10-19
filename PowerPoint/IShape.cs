namespace PowerPoint
{
    public interface IShape
    {
        /* get info */
        string GetInfo();

        /* get shape name */
        string GetShapeName();

        /* draw */
        void Draw(System.Drawing.Graphics graphics, System.Drawing.Pen pen);
    }
}
