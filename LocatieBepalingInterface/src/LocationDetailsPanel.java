import javax.swing.*;
import javax.swing.border.Border;
import javax.swing.plaf.FontUIResource;
import java.awt.*;
import java.util.ArrayList;
import java.util.List;

public class LocationDetailsPanel extends JPanel
{
    private JTextArea locationInfo;
    private List<Tag> tagDetails;
    //private Tag tag;

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
    public void addTag(Tag tag)
    {
//        tag.setTagID(id);
//        tag.setTagX(x);
//        tag.setTagY(y);
        tagDetails.add(tag);

        updateLocation(tag.getTagID(), tag.getTagX(), tag.getTagY());
    }

    // For updating text location
    public void updateLocation(String id, double x, double y)
    {
        StringBuilder sb = new StringBuilder();
        sb.append("Tag ID:      X:          Y:\n");

        for(Tag tag : tagDetails) {
            if (tag.getTagID().equals(id)) {
                tag.setTagX(x);
                tag.setTagY(y);
                //repaint();
                //return;
            }
        }
        for(Tag tag : tagDetails)
        {
            sb.append(String.format("Tag %-8s X: %-8s Y: %-8s%n", tag.getTagID(), tag.getTagX(), tag.getTagY()));
        }
        locationInfo.setText(sb.toString());
    }

    public List<Tag> getTagDetails() {
        return tagDetails;
    }
}
