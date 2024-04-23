import javax.swing.*;
import java.awt.*;
import javax.swing.border.Border;

public class LocationMapPanel extends JPanel
{
    // Map panel
    public LocationMapPanel()
    {
        setBackground(Color.WHITE);
        setPreferredSize(new Dimension(400,600));

        Border grayBorder = BorderFactory.createLineBorder(Color.LIGHT_GRAY, 5);
        setBorder(grayBorder);
    }

    // New paintComponent function
    @Override
    protected void paintComponent(Graphics g)
    {
        super.paintComponent(g);
        // TO DO: paint tag
        g.setColor(Color.red);
        g.fillOval(200, 300, 10, 10);
    }
}
