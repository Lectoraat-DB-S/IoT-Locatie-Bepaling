import javax.swing.*;

public class main extends JFrame
{
    public main()
    {
        setTitle("Locatie Bepaling");
        setSize(800, 600);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    }

    public static void main(String[] args)
    {
        main frame = new main();
        frame.setVisible(true);
    }
}

