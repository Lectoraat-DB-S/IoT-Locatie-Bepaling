import javax.swing.*;
import java.awt.*;

public class main extends JFrame
{
    public main()
    {
        setTitle("Locatie Bepaling");
        setSize(800, 600);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLayout(new GridLayout(1, 2));

        LocationMapPanel liveLocationPanel = new LocationMapPanel();
        LocationDetailsPanel textLocationPanel = new LocationDetailsPanel();

        add(liveLocationPanel);
        add(textLocationPanel);
    }

    public static void main(String[] args)
    {
        main frame = new main();
        frame.setVisible(true);
    }
}

