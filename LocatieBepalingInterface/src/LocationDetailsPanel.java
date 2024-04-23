import javax.swing.*;
import javax.swing.border.Border;
import java.awt.*;

public class LocationDetailsPanel extends JPanel
{
    private JTextArea locationInfo;

    public LocationDetailsPanel()
    {
        setBackground(Color.WHITE);
        setPreferredSize(new Dimension(400, 200));
        locationInfo = new JTextArea(10, 30);
        locationInfo.setEditable(false);
        JScrollPane scrollPane = new JScrollPane(locationInfo);
        add(scrollPane);

        Border grayBorder = BorderFactory.createLineBorder(Color.LIGHT_GRAY, 5);
        setBorder(grayBorder);

        // TO DO: Live location text update
        locationInfo.setText("Put location data here");
    }

    // For updating text location
    public void updateLocation(String data)
    {
        locationInfo.setText(data);
        repaint();
    }
}
