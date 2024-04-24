import javax.swing.*;
import java.awt.*;
import java.util.List;
import javax.swing.border.Border;

public class LocationMapPanel extends JPanel
{
    private LocationDetailsPanel textLocationPanel;

    // Map panel
    public LocationMapPanel()
    {
        setBackground(Color.WHITE);
        setPreferredSize(new Dimension(400,600));

        Border grayBorder = BorderFactory.createLineBorder(Color.LIGHT_GRAY, 5);
        setBorder(grayBorder);
    }

    /*
    public void updateMap()
    {
        List<String[]> tagDetails = textLocationPanel.getTagDetails();

        for(String[] tag: tagDetails)
        {
            if(tag.length == 3)
            {

            }
        }
    }
     */

    // TO DO: Add x and y
    // New paintComponent function
    protected void paintComponent(Graphics g, int x, int y)
    {
        super.paintComponent(g);
        // TO DO: paint tag
        g.setColor(Color.red);
        g.fillOval(x, y, 10, 10);
    }
}
