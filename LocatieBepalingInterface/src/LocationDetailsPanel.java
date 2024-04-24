import javax.swing.*;
import javax.swing.border.Border;
import javax.swing.plaf.FontUIResource;
import java.awt.*;
import java.util.ArrayList;
import java.util.List;

public class LocationDetailsPanel extends JPanel
{
    private JTextArea locationInfo;
    private List<String[]> tagDetails;

    public LocationDetailsPanel()
    {
        setBackground(Color.WHITE);
        setLayout(new BorderLayout());
        setPreferredSize(new Dimension(400, 200));

        locationInfo = new JTextArea(30, 40);
        locationInfo.setEditable(false);
        locationInfo.setFont(new Font("Monospaced", Font.PLAIN, 12));

        JScrollPane scrollPane = new JScrollPane(locationInfo);
        add(scrollPane, BorderLayout.CENTER);

        Border grayBorder = BorderFactory.createLineBorder(Color.LIGHT_GRAY, 5);
        setBorder(grayBorder);

        tagDetails = new ArrayList<>();
    }

    // Adding tags
    public void addTag(String id, String x, String y)
    {
        tagDetails.add(new String[]{id, x, y});
        updateLocation();
    }

    // For updating text location
    public void updateLocation()
    {
        StringBuilder sb = new StringBuilder();
        sb.append("Tag ID:      X:          Y:\n");

        for(String[] tag: tagDetails)
        {
            if(tag.length == 3)
            {
                sb.append(String.format("Tag %-8s X: %-8s Y: %-8s%n", tag[0], tag[1], tag[2]));
            }
        }

        locationInfo.setText(sb.toString());
        repaint();
    }
}
