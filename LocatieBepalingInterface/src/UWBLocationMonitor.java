import javax.swing.*;
import java.awt.*;

public class UWBLocationMonitor extends JFrame
{
    public UWBLocationMonitor()
    {
        setTitle("Locatie Bepaling");
        setSize(1200, 600);
        setMinimumSize(new Dimension(1200, 600));
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLayout(new GridBagLayout());


        GridBagConstraints gbc = new GridBagConstraints();

        LocationMapPanel liveLocationPanel = new LocationMapPanel();
        LocationDetailsPanel textLocationPanel = new LocationDetailsPanel();

        // Configuration for both Panels
        gbc.fill = GridBagConstraints.BOTH;
        gbc.weighty = 1.0;

        // Configuration for Map Panel
        gbc.gridx = 0;
        gbc.gridy = 0;
        gbc.weightx = 0.7;

        add(liveLocationPanel, gbc);

        // Configuration for Text Panel
        gbc.gridx = 1;
        gbc.weightx = 0.3;

        add(textLocationPanel, gbc);
    }

    public static void main(String[] args)
    {
        UWBLocationMonitor frame = new UWBLocationMonitor();
        frame.setVisible(true);
    }
}

